using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class NewsletterUserListPresenter : AbstractControlPresenter<INewsletterUserViewItem>, INewsletterUserListPresenter
    {
        private readonly NewsletterService newsletterUserService;

        public NewsletterUserListPresenter(INewsletterUserViewItem view)
            : base(view)
        {
            newsletterUserService = new NewsletterService();
        }

        private void DoSetNewsletterUserList(IList<NewsletterUser> list)
        {
            View.SetNewsletterUserList(list.Select(c => new NewsletterUserViewItem(c)).ToArray());
        }

        public void InitView()
        {
            DoLoad();
        }

        private void DoLoad()
        {
            var task = new Task<IList<NewsletterUser>>(() =>
            {
                View.ShowWaitingPanel("Carregando usuários...");
                return newsletterUserService.FindAll();
            });
            task.ContinueWith(t =>
            {
                DoSetNewsletterUserList(t.Result);
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao carregar a lista de usuários: {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnAddNewsletterUser()
        {
            var dialogResult = View.OpenAddNewsletterUserView();
            if (dialogResult == DialogResult.OK)
            {
                DoLoad();
            }
        }

        public void OnExportToExcel()
        {
            var task = new Task<string>(() =>
            {
                var filePath = View.SelectFilePathToSaveExcelFile();
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    return null;
                }
                View.ShowWaitingPanel("Exportando lista de usuários para excel...");
                newsletterUserService.ExportToExcel(View.GetNewsletterUserList().Select(i => i.Wrapper).ToArray(), filePath);
                return filePath;
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                if (t.Result != null)
                {
                    View.ShowSuccessMessage(string.Format("Planilha excel foi gerada em '{0}'", t.Result));
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao gerar a tabela: {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnRemoveNewsletterUser()
        {
            var task = new Task<NewsletterUserViewItem>(() =>
            {
                var newsletterUserViewItem = View.GetNewsletterUserSelected();
                if (newsletterUserViewItem != null)
                {
                    if (View.ShowBinaryQuestion("Deseja excluir este usuário?"))
                    {
                        View.ShowWaitingPanel(string.Format("Excluindo usuário - {0}...", newsletterUserViewItem.Name));
                        newsletterUserService.RemoveNewsletterUser(newsletterUserViewItem.Wrapper);
                    }
                }
                else
                {
                    View.ShowWarningMessage("Selecione o usuário que deseja excluir");
                }
                return newsletterUserViewItem;
            });
            task.ContinueWith(t =>
            {
                var newsletterViewItem = t.Result;
                if (newsletterViewItem != null)
                {
                    try
                    {
                        DoSetNewsletterUserList(newsletterUserService.FindAll());
                    }
                    catch (Exception)
                    {
                        View.ShowWarningMessage(
                            string.Format(
                                "O usuário {0} foi excluído, porém houve um erro ao atualizar a lista de newsletter. Por favor, tente entrar nesta opção novamente.", newsletterViewItem.Name));
                    }
                }
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao excluir o colaborador: {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnSelectNewsletterUserView()
        {
            var selected = View.GetNewsletterUserSelected();
            if (selected != null)
            {
                var result = View.OpenNewsletterUserViewSelected(selected);
                if (result == DialogResult.OK)
                {
                    DoLoad();
                }
            }
        }
    }
}
