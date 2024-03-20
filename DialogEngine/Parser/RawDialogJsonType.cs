using Newtonsoft.Json;

namespace DialogEngine.Parser
{
    public class RawDialogJsonType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public NodeType Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }


        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("next")]
        public int Next { get; set; }

        [JsonProperty("nodes")]
        public DialogOptionRawType[] Nodes { get; set; }
    }
}