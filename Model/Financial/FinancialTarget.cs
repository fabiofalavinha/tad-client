using Newtonsoft.Json;

namespace TadManagementTool.Model.Financial
{
    public class FinancialTarget
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public FinancialTargetType Type { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
