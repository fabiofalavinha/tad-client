using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public class Element
    {
        [JsonProperty ("primaryCollaborator")]
        public Collaborator PrimaryCollaborator { get; set; }

        [JsonProperty("secondaryCollaborator")]
        public Collaborator SecondaryCollaborator { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
