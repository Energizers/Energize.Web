using Newtonsoft.Json;

namespace Energize.Web.Models
{
    public class GitlabPipelineAttributes
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class GitlabPipelineObject
    {
        [JsonProperty("object_kind")]
        public string Kind { get; set; }

        [JsonProperty("object_attributes")]
        public GitlabPipelineAttributes Attributes { get; set; }
    }
}
