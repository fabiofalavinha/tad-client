using System.Threading.Tasks;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.Validator;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class NewsletterUserPresenter : AbstractControlPresenter<INewsletterUserView>, INewsletterUserPresenter
    {
        private readonly NewsletterUserViewItem viewItem;

        public NewsletterUserPresenter(INewsletterUserView view, NewsletterUserViewItem viewItem)
            : base(view)
        {
            this.viewItem = viewItem;
        }

        public void InitView()
        {
            if (viewItem != null)
            {
                View.SetName(viewItem.Name);
                View.SetEmail(viewItem.Email);
            }
        }

        public void OnSave()
        {
            var task = new Task<bool>(() =>
            {
                View.ShowWaitingPanel("Salvando dados do usuário...");
                var name = View.GetName();
                if (string.IsNullOrWhiteSpace(name))
                {
                    View.ShowWarningMessage("É obrigatório informar um nome");
                    return false;
                }
                var email = View.GetEmail();
                if (string.IsNullOrWhiteSpace(email))
                {
                    View.ShowWarningMessage("É obrigatório informar o email");
                    return false;
                }
                var emailValidator = new EmailValidator();
                if (!emailValidator.Validate(email))
                {
                    View.ShowWarningMessage("Informe um email válido");
                    return false;
                }
                var user = new NewsletterUser()
                {
                    Name = name,
                    Email = email
                };
                if (viewItem != null)
                {
                    user.Id = viewItem.Wrapper.Id;
                }
                new NewsletterService().SaveNewsletterUser(user);
                return true;
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao salvar as informações do usuário: {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                View.SetDialogResult(t.Result ? DialogResult.OK : DialogResult.Cancel);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }

        public void OnCancel()
        {
            View.SetDialogResult(DialogResult.Cancel);
        }
    }
}
