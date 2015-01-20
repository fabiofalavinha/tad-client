using Spring.Http.Converters.Json;
using Spring.Rest.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TadManagementTool.Model;
using TadManagementTool.Service.VOs;

namespace TadManagementTool.Service
{
    public class UserCredentialsService : AbstractService
    {
        public User Authenticate(string userName, string password)
        {
            return  restTemplate.PostForObject<User>("/security/authenticate", new AuthenticationRequest() { UserName = userName, Password = password });
        }
    }
}
