using Energize.Web.Models;
using Energize.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Energize.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly ITransmissionService TransmissionService;

        public InfoController(ITransmissionService transmission)
        {
            this.TransmissionService = transmission;
        }

        // GET: api/info
        [HttpGet]
        public async Task<BotInformation> Get() 
            => await this.TransmissionService.TransmitToEnergizeAsync<BotInformation>("info");

    }
}
