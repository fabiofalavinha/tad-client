using Newtonsoft.Json;
using System.Collections.Generic;

namespace TadManagementTool.Model
{
    public class Consecration
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }

        [JsonProperty("elements")]
        public List<Element> Elements { get; set; }

        [JsonProperty("message")]
        public CommunicationMessage Message { get; set; }
    }
}
