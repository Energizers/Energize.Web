using Newtonsoft.Json;

namespace Energize.Web.Models
{
    public class DiscordBotsVote
    {
        [JsonProperty("bot")]
        public ulong BotId { get; set; }

        [JsonProperty("user")]
        public ulong UserId { get; set; }

        [JsonProperty("isWeekend")]
        public bool IsWeekend { get; set; }
    }
}
