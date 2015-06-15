using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class EventEnrollmentPresenter : AbstractDialogPresenter<IEventEnrollmentView>, IEventEnrollmentPresenter
    {
        private readonly EventService eventService;

        public EventEnrollmentPresenter(IEventEnrollmentView view)
            : base(view)
        {
            eventService = new EventService();
        }

        public void InitView()
        {
        }

        public void OnCancel()
        {
            View.SetDialogResult(DialogResult.Cancel);
        }

        public void OnOk()
        {
            var task = new Task<Event>(() =>
            {
                View.ShowWaitingPanel("Criando evento...");
                var title = View.GetEventTitle();
                if (string.IsNullOrWhiteSpace(title))
                {
                    View.ShowWarningMessage("Título do evento é obrigatório");
                    return null;
                }
                var date = View.GetEventDate();
                var notes = View.GetEventNotes();
                var newEvent = new Event()
                {
                    Title = title,
                    Date = date,
                    Notes = notes,
                    Visibility = View.GetEventVisibility()
                };
                eventService.AddEvent(newEvent);
                return newEvent;
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                var newEvent = t.Result;
                if (newEvent != null)
                {
                    View.EventResult = newEvent;
                    View.SetDialogResult(DialogResult.OK);
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions) 
                {
                    View.ShowErrorMessage(innerException.Message);
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }
    }
}
