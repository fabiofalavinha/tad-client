using System.Threading.Tasks;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Properties;
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
            View.SetUserName(View.GetLastUserStored());
        }

        public void OnCancel()
        {
            View.CloseView();
        }

        public void OnSingIn()
        {
            var task = new Task<User>(() =>
            {
                View.ShowWaitingPanel("Sign in...");
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
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Não foi possível realizar a sua autenticação. {0}", innerException.Message));
                }
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }
    }
}
