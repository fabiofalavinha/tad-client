using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public class Event
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("visibility")]
        public VisibilityType Visibility { get; set; }
    }
}
