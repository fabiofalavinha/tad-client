
using System;
using TadManagementTool.Model;

namespace TadManagementTool.View.Impl
{
    public class OpenCalendarMenuViewAction : IMenuActionView
    {
        public bool CanUserAccess(User user)
        {
            return user.IsAdministratorProfile;
        }

        public void Open(IMainView mainView)
        {
            mainView.OpenCalendarView();
        }
    }
}
