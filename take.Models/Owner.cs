using Newtonsoft.Json;

namespace take.Models
{
    public class Owner
    {
        [JsonProperty("avatar_url")]
        public string Avatar { get; set; }
    }
}
