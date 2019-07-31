using Energize.Web.Models;
using Energize.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Energize.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly ITransmissionService TransmissionService;

        public WebhookController(ITransmissionService transmission)
        {
            this.TransmissionService = transmission;
        }

        private async Task<(bool, string)> TryReadBodyAsync()
        {
            try
            {
                Stream stream = this.Request.Body;
                byte[] buffer = new byte[short.MaxValue];
                using (MemoryStream ms = new MemoryStream())
                {
                    while (true)
                    {
                        int read = await stream.ReadAsync(buffer, 0, buffer.Length);
                        if (read <= 0)
                        {
                            buffer = ms.ToArray();
                            break;
                        }

                        await ms.WriteAsync(buffer, 0, read);
                    }
                }

                return (true, Encoding.UTF8.GetString(buffer));
            }
            catch
            {
                return (false, string.Empty);
            }
        }

        private bool TryDeserialize<T>(string json, out T value)
        {
            try
            {
                value = JsonConvert.DeserializeObject<T>(json);
                return true;
            }
            catch
            {
                value = default;
                return false;
            }
        }

        // POST: api/Webhook
        [HttpPost]
        public async Task Post()
        {
            (bool success, string body) = await this.TryReadBodyAsync();
            if (success)
            {
                if (this.Request.Headers.TryGetValue("X-Gitlab-Token", out StringValues token) 
                    && token.ToString().Equals(Config.Instance.Webhook.GitlabToken)
                    && this.Request.Headers.TryGetValue("X-Gitlab-Event", out StringValues gitlabEvent) 
                    && gitlabEvent.ToString().Equals("Pipeline Hook")
                    && this.TryDeserialize(body, out GitlabPipelineObject gitlabObj)
                    && gitlabObj.Attributes.Status.Equals("success"))
                {
                    await this.TransmissionService.TransmitToEnergizeAsync("update");
                }
                else if (this.Request.Headers.TryGetValue("Authorization", out StringValues authorization) 
                    && authorization.ToString().Equals(Config.Instance.Webhook.DiscordBotsToken) 
                    && this.TryDeserialize(body, out DiscordBotsVote vote))
                {
                    await this.TransmissionService.TransmitToEnergizeAsync("upvote", vote);
                }
            }
        }
    }
}
