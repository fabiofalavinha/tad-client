using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model.Financial
{
    public class FinancialReference
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "category")]
        public int Category { get; set; }

        [JsonProperty(PropertyName = "associatedWithCollaborator")]
        public bool AssociatedWithCollaborator { get; set; }
    }
}
