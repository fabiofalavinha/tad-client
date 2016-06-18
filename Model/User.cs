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

        public bool IsAdministratorProfile { get { return ToUserRole() == Model.UserRole.Administrator; } }

        public bool IsFinancialProfile { get { return ToUserRole() == Model.UserRole.Financial; } }

        public UserRole ToUserRole()
        {
            var enumName = Enum.GetNames(typeof(UserRole)).SingleOrDefault(e => e.ToLower().Equals(UserRole.ToLower()));
            return (UserRole)Enum.Parse(typeof(UserRole), enumName);
        }
    }
}
