using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Energize.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        public async Task<(bool, string)> TryReadBodyAsync()
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

        // POST: api/Webhook
        [HttpPost]
        public async Task Post()
        {
            (bool success, string body) = await this.TryReadBodyAsync();
            if (success)
            {
                IPAddress ip = this.HttpContext.Connection.RemoteIpAddress;
                IPHostEntry ipHostEntry = await Dns.GetHostEntryAsync(ip);

                Console.WriteLine(ipHostEntry.HostName);
                Console.WriteLine(body);
            }
        }
    }
}
