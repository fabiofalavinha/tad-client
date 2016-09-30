using Newtonsoft.Json;

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
