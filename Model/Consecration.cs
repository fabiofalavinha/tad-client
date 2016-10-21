using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public class Consecration 
    {
        [JsonProperty("id")]
        public  string Id { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }

        [JsonProperty("elements")]
        public List<Element> Elements { get; set; }

        [JsonProperty("message")]
        public CommunicationMessage Message { get; set; }
    }
}
