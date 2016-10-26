using TadManagementTool.Model;

namespace TadManagementTool.View.Impl
{
    public class OpenConsecrationMenuViewAction : IMenuActionView
    {
        public bool CanUserAccess(User user)
        {
            return user.IsAdministratorProfile;
        }

        public void Open(IMainView mainView)
        {
            mainView.OpenConsecrationView();
        }
    }
}
