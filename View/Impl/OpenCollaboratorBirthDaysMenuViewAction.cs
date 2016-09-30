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
