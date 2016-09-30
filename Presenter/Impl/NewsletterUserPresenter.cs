using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;
using TadManagementTool.View.Impl;
using TadManagementTool.Validator;
using System.Threading.Tasks;
using TadManagementTool.Service;
using TadManagementTool.View.Items;
using System.Windows.Forms;

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
            var task = new Task(() =>
            {
                View.ShowWaitingPanel("Salvando dados do usuário...");
                var name = View.GetName();
                if (string.IsNullOrWhiteSpace(name))
                {
                    View.ShowWarningMessage("É obrigatório informar um nome");
                    return;
                }
                var email = View.GetEmail();
                if (string.IsNullOrWhiteSpace(email))
                {
                    View.ShowWarningMessage("É obrigatório informar o email");
                    return;
                }
                var emailValidator = new EmailValidator();
                if (!emailValidator.Validate(email))
                {
                    View.ShowWarningMessage("Informe um email válido");
                    return;
                }
                var newsletterService = new NewsletterService();
                newsletterService.SaveNewsletterUser(new NewsletterUser()
                {
                    Name = name,
                    Email = email
                });
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
                View.SetDialogResult(DialogResult.OK);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }

        public void OnCancel()
        {
            View.SetDialogResult(DialogResult.Cancel);
        }
    }
}
