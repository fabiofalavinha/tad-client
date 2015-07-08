using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class ListCollaboratorPresenter : AbstractControlPresenter<IListCollaboratorView>, IListCollaboratorPresenter
    {
        public ListCollaboratorPresenter(IListCollaboratorView view)
            : base(view)
        {
        }

        private void DoSetCollaboratorList(IList<Collaborator> list)
        {
            View.SetCollaboratorList(list.Select(c => new CollaboratorViewItem(c)).ToArray());
            View.SetActiveCollaboratorCount(list.Count(c => c.Active));
        }

        public void InitView()
        {
            var task = new Task<IList<Collaborator>>(() =>
            {
                View.ShowWaitingPanel("Carregando colaboradores...");
                var collaboratorService = new CollaboratorService();
                return collaboratorService.FindAll();
            });
            task.ContinueWith(t =>
            {
                DoSetCollaboratorList(t.Result);
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao carregar a lista de colaboradores: {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnRemoveCollaborator()
        {
            var collaboratorService = new CollaboratorService();
            var task = new Task<CollaboratorViewItem>(() =>
            {
                var collaboratorViewItem = (CollaboratorViewItem)View.GetCollaboratorSelected();
                if (collaboratorViewItem != null)
                {
                    if (View.ShowBinaryQuestion("Deseja excluir este colaborador?"))
                    {
                        View.ShowWaitingPanel(string.Format("Excluindo colaborador - {0}...", collaboratorViewItem.Name));
                        collaboratorService.RemoveCollaborator(collaboratorViewItem.Wrapper);
                    }
                }
                else
                {
                    View.ShowWarningMessage("Selecione o colaborador que deseja excluir");
                }
                return collaboratorViewItem;
            });
            task.ContinueWith(t =>
            {
                var collaboratorViewItem = t.Result;
                if (collaboratorViewItem != null)
                {
                    try
                    {
                        DoSetCollaboratorList(collaboratorService.FindAll());
                    }
                    catch (Exception)
                    {
                        View.ShowWarningMessage(
                            string.Format(
                                "O colaborador {0} foi excluído, porém houve um processo ao atualizar a lista de colaboradores. Por favor, tente entrar nesta opção novamente.", collaboratorViewItem.Name));
                    }
                }
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao excluir o colaborador: {0}", innerException.Message));
                }
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnNewCollaborator()
        {
            View.OpenCollaboratorView();
        }

        public void OnViewCollaboratorDetails()
        {
            var collaboratorViewItem = (CollaboratorViewItem)View.GetCollaboratorSelected();
            if (collaboratorViewItem != null)
            {
                View.OpenCollaboratorView(collaboratorViewItem.Wrapper);
            }
            else
            {
                View.ShowWarningMessage("Selecione o colaborador para ver os detalhes");
            }
        }
    }
}
