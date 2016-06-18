using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.View.Impl
{
    public class OpenImageListMenuViewAction : IMenuActionView
    {
        public bool CanUserAccess(User user)
        {
            return user.IsAdministratorProfile;
        }

        public void Open(IMainView mainView)
        {
            mainView.OpenImageListView();
        }
    }
}
