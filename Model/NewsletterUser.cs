using Newtonsoft.Json;
using System;

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

        [JsonProperty("status")]
        public int Status { get; set; }

        public NewsletterUserConfirmationStatus ToStatus()
        {
            return (NewsletterUserConfirmationStatus)Enum.ToObject(typeof(NewsletterUserConfirmationStatus), Status);
        }
    }
}
