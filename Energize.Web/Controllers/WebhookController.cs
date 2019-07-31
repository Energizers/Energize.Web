using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Energize.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        // POST: api/Webhook
        [HttpPost]
        public void Post([FromBody] Dictionary<string, string> values)
        {
            string json = JsonConvert.SerializeObject(values);
            Console.WriteLine(json);
        }
    }
}
