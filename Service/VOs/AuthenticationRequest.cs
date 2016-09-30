using Newtonsoft.Json;

namespace TadManagementTool.Service.VOs
{
    public class AuthenticationRequest
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
