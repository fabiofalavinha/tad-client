using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.View.Impl
{
    public class OpenCollaboratorBirthDaysMenuViewAction : IMenuActionView
    {
        public bool CanUserAccess(User user)
        {
            return user.IsAdministratorProfile || user.IsFinancialProfile;
        }

        public void Open(IMainView mainView)
        {
            mainView.OpenCollaboratorBirthDaysView();
        }
    }
}
