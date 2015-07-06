using TadManagementTool.Model;
using TadManagementTool.View;
using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class MainPresenter : AbstractDialogPresenter<IMainView>, IMainPresenter
    {
        public MainPresenter(IMainView mainView)
            : base(mainView)
        {
        }

        public void InitView()
        {
        }

        public void OnMenuItemSelect(IMenuActionView menuActionView)
        {
            menuActionView.Open(View);
        }

        public void OnUserChangePassword()
        {
            View.OpenUserChangePasswordView(UserContext.GetInstance().LoggedUser);
        }
    }
}
