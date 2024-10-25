using Newtonsoft.Json;

namespace SdetBootcampDay3.Models
{
    public class TakeHomeUserDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("job")]
        public string Job { get; set; } = string.Empty;
    }
}
