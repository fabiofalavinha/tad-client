using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public sealed class UserContext
    {
        private static UserContext instance;

        public static UserContext GetInstance()
        {
            if (instance == null)
                instance = new UserContext();
            return instance;
        }

        public User LoggedUser { get; set; }

        private UserContext()
        {
        }
    }
}
