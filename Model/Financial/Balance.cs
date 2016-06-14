using Newtonsoft.Json;

namespace TadManagementTool.Model.Financial
{
    public class Balance
    {
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}
