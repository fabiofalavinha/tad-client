using Newtonsoft.Json;

namespace TadManagementTool.Model
{
    public class NewsletterUser
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
