using Energize.Web.Models;
using Energize.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Energize.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ITransmissionService TransmissionService;

        public CommandsController(ITransmissionService transmission)
        {
            this.TransmissionService = transmission;
        }

        // GET: api/commands
        [HttpGet]
        public async Task<CommandInformation> Get()
            => await this.TransmissionService.TransmitToEnergizeAsync<CommandInformation>("commands");
    }
}
