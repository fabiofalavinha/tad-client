using Newtonsoft.Json;

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
