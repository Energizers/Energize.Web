using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Energize.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        // GET: api/Music
        [HttpGet]
        public string Get()
        {
            return "unimplemented";
        }
    }
}
