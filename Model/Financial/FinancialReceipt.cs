using Newtonsoft.Json;

namespace TadManagementTool.Model.Financial
{
    public class FinancialReceipt
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        [JsonProperty(PropertyName = "sent")]
        public string Sent { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "target")]
        public Collaborator Target { get; set; }

        [JsonProperty(PropertyName = "entry")]
        public FinancialEntry Entry { get; set; }
    }
}
