using Newtonsoft.Json;

namespace TadManagementTool.Model.Financial
{
    public class FinancialTarget
    {
        [JsonProperty("type")]
        public FinancialTargetType Type { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
