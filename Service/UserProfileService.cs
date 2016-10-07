using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;
using TadManagementTool.Persistence;

namespace TadManagementTool.Service
{
    public class UserProfileService
    {
        private readonly UserProfileDAO userProfileDAO;

        public UserProfileService()
        {
            userProfileDAO = new UserProfileDAO();                     
        }

        public void SaveProfile(UserProfile userProfile)
        {
            userProfileDAO.SaveProfile(userProfile);
        }

        public UserProfile LoadProfile(User user)
        {
            return userProfileDAO.LoadProfile(user);
        }
    }
}
