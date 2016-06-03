using Newtonsoft.Json;
using System;

namespace TadManagementTool.Model.Financial
{
    public class FinancialEntry
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        public FinancialEntry()
        {
            Id = Guid.NewGuid().ToString();
            Date = DateTime.Now;
        }
    }
}
