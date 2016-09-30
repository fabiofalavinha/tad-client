using TadManagementTool.Model;
using TadManagementTool.Service.VOs;

namespace TadManagementTool.Service
{
    public class UserCredentialsService : AbstractService
    {
        public User Authenticate(string userName, string password)
        {
            return  restTemplate.PostForObject<User>("/authenticate", new AuthenticationRequest() { UserName = userName, Password = password });
        }

        public void ChangePassword(string newPassword, string currentPassword, User user)
        {
            restTemplate.PostForObject<ChangePasswordRequest>("/changePassword", new ChangePasswordRequest() { Id = user.Id, NewPassword = newPassword, OldPassword = currentPassword });
        }
    }
}
