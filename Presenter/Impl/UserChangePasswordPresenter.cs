using System.Threading.Tasks;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View;

namespace TadManagementTool.Presenter.Impl
{
    public class UserChangePasswordPresenter : AbstractDialogPresenter<IUserChangePasswordView>, IUserChangePasswordPresenter
    {
        private readonly User user;

        public UserChangePasswordPresenter(IUserChangePasswordView view, User user)
            : base(view)
        {
            this.user = user;
        }

        public void InitView()
        {
             // do nothing
        }

        public void OnOk()
        {
            var task = new Task<bool>(() =>
            {
                var currentPassword = View.GetCurrentPassword();
                if (string.IsNullOrWhiteSpace(currentPassword))
                {
                    View.ShowWarningMessage("Informe a sua senha atual");
                    return false;
                }
                var newPassword = View.GetNewPassword();
                if (string.IsNullOrWhiteSpace(newPassword))
                {
                    View.ShowWarningMessage("Informe a nova senha");
                    return false;
                }
                var confirmNewPassword = View.GetConfirmNewPassword();
                if (string.IsNullOrWhiteSpace(confirmNewPassword))
                {
                    View.ShowWarningMessage("Confirme a nova senha");
                    return false;
                }
                if (!confirmNewPassword.Equals(newPassword))
                {
                    View.ShowWarningMessage("A nova senha não é igual a senha de confirmação");
                    return false;
                }
                View.ShowWaitingPanel("Alterando a senha...");
                var userCredentialsService = new UserCredentialsService();
                userCredentialsService.ChangePassword(confirmNewPassword, currentPassword, user);
                return true;
            });
            task.ContinueWith(t =>
            {
                if (t.Result)
                {
                    View.HideWaitingPanel();
                    View.SetDialogResult(DialogResult.OK);
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao alterar a senha. Tente repetir a operação. {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnCancel()
        {
            View.SetDialogResult(DialogResult.Cancel);
        }
    }
}
