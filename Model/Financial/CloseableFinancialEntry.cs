using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model.Financial
{
    public class CloseableFinancialEntry
    {
        [JsonProperty("closedDate")]
        public string ClosedDate { get; set; }

        [JsonProperty("closedBy")]
        public User ClosedBy { get; set; }
    }
}
