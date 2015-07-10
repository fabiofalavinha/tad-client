using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Service.VOs
{
    public class ChangePasswordRequest
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "oldPassword")]
        public string OldPassword { get; set; }

        [JsonProperty(PropertyName = "newPassword")]
        public string NewPassword { get; set; }
    }
}
