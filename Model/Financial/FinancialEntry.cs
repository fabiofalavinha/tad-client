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

        [JsonProperty(PropertyName = "target")]
        public FinancialTarget Target { get; set; }

        [JsonProperty(PropertyName = "type")]
        public FinancialReference Type { get; set; }

        [JsonProperty(PropertyName = "additionalText")]
        public string AdditionalText { get; set; }

        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }

        [JsonProperty(PropertyName = "balance")]
        public Balance Balance { get; set; }

        [JsonProperty(PropertyName = "previewBalance")]
        public Balance PreviewBalance { get; set; }

        public FinancialEntry()
        {
            Id = Guid.NewGuid().ToString();
            Date = DateTime.Now;
        }
    }
}
