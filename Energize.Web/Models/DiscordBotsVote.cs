using Newtonsoft.Json;

namespace Energize.Web.Models
{
    public class DiscordBotsVote
    {
        [JsonProperty("bot")]
        public ulong BotId;

        [JsonProperty("user")]
        public ulong UserId;

        [JsonProperty("isWeekend")]
        public bool IsWeekend;
    }
}
