using System.Threading.Tasks;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class LoginPresenter : AbstractDialogPresenter<ILoginView>, ILoginPresenter
    {
        public LoginPresenter(ILoginView loginView)
            : base(loginView)
        {
        }

        public void InitView()
        {
            var userName = View.GetLastUserStored();
            if (!string.IsNullOrWhiteSpace(userName))
            {
                View.SetUserName(userName);
                View.SetPasswordFocus();
            }
        }

        public void OnCancel()
        {
            View.CloseView();
        }

        public void OnSingIn()
        {
            var task = new Task<User>(() =>
            {
                View.ShowWaitingPanel("Autenticando...");
                var userName = View.GetUserName();
                var password = View.GetPassword();
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                {
                    View.ShowWarningMessage("Usuário e/ou senha inválidos!");
                    return null;
                }
                var userCredentialsService = new UserCredentialsService();
                return userCredentialsService.Authenticate(userName, password);
            });
            task.ContinueWith(t =>
            {
                var result = t.Result;
                if (result != null)
                {
                    UserContext.GetInstance().LoggedUser = result;
                    View.StoreLastUserName(result.UserName);
                    View.SetDialogResult(DialogResult.OK);
                }
                else
                {
                    View.ShowWarningMessage("Usuário e/ou senha inválidos!");
                }
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                View.ShowErrorMessage("Ocorreu um erro na autenticação. Tenta mais uma vez e se o problema persistir contacte o administrador do sistema.");
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }
    }
}
