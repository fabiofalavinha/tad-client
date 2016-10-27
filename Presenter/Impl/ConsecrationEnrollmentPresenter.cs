using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class ConsecrationEnrollmentPresenter : AbstractDialogPresenter<IConsecrationEnrollmentView>, IConsecrationEnrollmentPresenter 
    {
        private readonly EventService eventService;
        private readonly string eventId;

        public ConsecrationEnrollmentPresenter(IConsecrationEnrollmentView view, string eventId)
            : base(view)
        {
            eventService = new EventService();
            this.eventId = eventId;
        }

        public void InitView()
        {
            var task = new Task<Consecration>(() =>
            {
                View.ShowWaitingPanel("Carregando dados da consagração...");
                return eventService.FindConsecrationByEventId(eventId);

            });
            task.ContinueWith(t =>
            {
                var consecration = t.Result;
                if (consecration != null)
                {
                    View.SetElementList(consecration.Elements);
                    View.SetComunicationMessage(consecration.Message);
                }
            },TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public void OnSaveConsecration()
        {
            var task = new Task(() =>
            {
                
            });
        }
    }
}
