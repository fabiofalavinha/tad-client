using Newtonsoft.Json;

namespace TadManagementTool.Model.Financial
{
    public class FinancialReceiptInfo
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("sent")]
        public string Sent { get; set; }
    }
}
