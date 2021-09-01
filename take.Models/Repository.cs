using Newtonsoft.Json;

namespace take.Models
{
    public class Repository
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }
    }
}
