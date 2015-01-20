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
        }

        public void OnNewCollaborator()
        {
        }

        public void OnViewCollaboratorDetails()
        {
        }
    }
}
