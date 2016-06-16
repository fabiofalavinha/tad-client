using Newtonsoft.Json;
using System;

namespace TadManagementTool.Model.Financial
{
    public class FinancialTarget
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public FinancialTargetType ToTargetType()
        {
            return (FinancialTargetType)Enum.ToObject(typeof(FinancialTargetType), Type);
        }
    }
}
