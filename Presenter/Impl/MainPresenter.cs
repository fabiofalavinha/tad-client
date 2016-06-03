using System;
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

        public void OnMenuItemSelect(string menuActionTypeViewString)
        {
            if (!string.IsNullOrWhiteSpace(menuActionTypeViewString))
            {
                try
                {
                    var menuActionView = Activator.CreateInstance(Type.GetType(menuActionTypeViewString)) as IMenuActionView;
                    if (menuActionView != null)
                    {
                        menuActionView.Open(View);
                    }
                    else
                    {
                        View.ShowWarningMessage($"Não foi possível abrir a tela [{menuActionTypeViewString}]");
                    }
                }
                catch (Exception ex)
                {
                    View.ShowWarningMessage($"Não foi possível executar a oporação desejada [{ex.Message}]");
                }
            }
        }

        public void OnUserChangePassword()
        {
            View.OpenUserChangePasswordView(UserContext.GetInstance().LoggedUser);
        }
    }
}
