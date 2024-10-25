using Newtonsoft.Json;

namespace SdetBootcampDay3.Models
{
    public class UserDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("username")]
        public string Username { get; set; } = string.Empty;
        
        [JsonProperty("company")]
        public CompanyDto Company { get; set; }
    }
}
