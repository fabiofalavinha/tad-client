using Newtonsoft.Json;

namespace TadManagementTool.Service.VOs
{
    public class CloseFinancialEntryBalanceDTO
    {
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }
    }
}
