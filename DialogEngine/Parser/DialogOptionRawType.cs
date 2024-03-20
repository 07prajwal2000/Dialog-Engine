using Newtonsoft.Json;

namespace DialogEngine.Parser
{
    public class DialogOptionRawType
    {
        [JsonProperty("next")]
        public int Next { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}