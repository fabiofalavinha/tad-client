using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Service.VOs
{
    public class CloseFinancialEntryBalanceDTO
    {
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }
    }
}
