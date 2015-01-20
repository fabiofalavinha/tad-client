using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View;
using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class ListCollaboratorPresenter : AbstractControlPresenter<IListCollaboratorView>, IListCollaboratorPresenter
    {
        public ListCollaboratorPresenter(IListCollaboratorView view)
            : base(view)
        {
        }

        public void InitView()
        {
            var task = new Task<IList<Collaborator>>(() =>
            {
                View.ShowWaitingPanel("Carregando...");
                var collaboratorService = new CollaboratorService();
                return collaboratorService.FindAll();
            });
            task.ContinueWith(t =>
            {
                View.SetCollaboratorList(t.Result);
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao carregar a lista de colaboradores: {0}", innerException.Message));
                }
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnRemoveCollaborator()
        {
            var collaboratorService = new CollaboratorService();
            var task = new Task<Collaborator>(() =>
            {
                var collaborator = (Collaborator)View.GetCollaboratorSelected();
                if (collaborator != null)
                {
                    if (View.ShowBinaryQuestion("Deseja excluir este colaborador?"))
                    {
                        View.ShowWaitingPanel(string.Format("Excluindo colaborador - {0}...", collaborator.Name));
                        collaboratorService.RemoveCollaborator(collaborator);
                    }
                }
                else
                {
                    View.ShowWarningMessage("Selecione o colaborador que deseja excluir");
                }
                return collaborator;
            });
            task.ContinueWith(t =>
            {
                var collaborator = t.Result;
                if (collaborator != null)
                {
                    try
                    {
                        View.SetCollaboratorList(collaboratorService.FindAll());
                    }
                    catch (Exception)
                    {
                        View.ShowWarningMessage(
                            string.Format(
                                "O colaborador {0} foi excluído, porém houve um processo ao atualizar a lista de colaboradores. Por favor, tente entrar nesta opção novamente.", collaborator.Name));
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
            var collaborator = (Collaborator)View.GetCollaboratorSelected();
            if (collaborator != null)
            {
                View.OpenCollaboratorView(collaborator);
            }
            else
            {
                View.ShowWarningMessage("Selecione o colaborador para ver os detalhes");
            }
        }
    }
}
