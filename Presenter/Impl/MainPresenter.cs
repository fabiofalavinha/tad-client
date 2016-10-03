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
            View.SetApplicationVersion(ApplicationVersion.Version);
            View.ConfigureMenuPermissions();
        }

        public bool OnMenuItemAccess(string menuActionTypeViewString)
        {
            var menuActionView = CreateMenuAction(menuActionTypeViewString);
            return menuActionView.CanUserAccess(UserContext.GetInstance().LoggedUser);
        }

        public void OnMenuItemSelect(string menuActionTypeViewString)
        {
            if (!string.IsNullOrWhiteSpace(menuActionTypeViewString))
            {
                try
                {
                    var menuActionView = CreateMenuAction(menuActionTypeViewString);
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

        private static IMenuActionView CreateMenuAction(string menuActionTypeViewString)
        {
            return Activator.CreateInstance(Type.GetType(menuActionTypeViewString)) as IMenuActionView;
        }

        public void OnUserChangePassword()
        {
            View.OpenUserChangePasswordView(UserContext.GetInstance().LoggedUser);
        }
    }
}
