using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public class User
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("userRole")]
        public string UserRole { get; set; }
    }
}
