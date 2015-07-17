using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class CollaboratorBirthDaysPresenter : AbstractControlPresenter<ICollaboratorBirthDaysView>, ICollaboratorBirthDaysPresenter
    {
        public CollaboratorBirthDaysPresenter(ICollaboratorBirthDaysView view)
            : base(view)
        {
        }

        public void InitView()
        {
            var task = new Task<IList<BirthdayList>>(() =>
            {
                View.ShowWaitingPanel("Carregando aniversariantes dos póximos meses...");
                var collaboratorService = new CollaboratorService();
                return collaboratorService.FindCurrentYearBirthDays();
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                View.SetBirthdayList(t.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao carregar os aniversariantes. Tente repetir a operação. {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }
    }
}
