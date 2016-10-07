using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public class UserProfile
    {
        public User User { get; private set; }

        public CollaboratorPreferences CollaboratorPreferences { get; set; }

        public UserProfile(User user)
        {
            User = user;
        }
    }
}
