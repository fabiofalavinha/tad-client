using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class UserRoleViewItem
    {
        public UserRole Wrapper { get; private set; }

        public UserRoleViewItem(UserRole userRole)
        {
            Wrapper = userRole;
        }

        public override string ToString()
        {
            return Wrapper.ToString();
        }
    }
}
