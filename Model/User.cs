using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("userRole")]
        public string UserRole { get; set; }
    }
}
