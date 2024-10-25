using Newtonsoft.Json;

namespace SdetBootcampDay3.Models
{
    public class JokeDto
    {
        [JsonProperty("id")]
        public string Id {  get; set; } = string.Empty;

        [JsonProperty("joke")]
        public string Joke { get; set; } = string.Empty;

        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
