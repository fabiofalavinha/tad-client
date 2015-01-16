using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class LoginPresenter : AbstractPresenter<ILoginView>, ILoginPresenter
    {
        public LoginPresenter(ILoginView loginView)
            : base(loginView)
        {
        }

        public void InitView()
        {
        }

        public void OnCancel()
        {
        }

        public void OnSingIn()
        {
        }
    }
}
