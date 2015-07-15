using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class EventEnrollmentPresenter : AbstractDialogPresenter<IEventEnrollmentView>, IEventEnrollmentPresenter
    {
        private readonly EventService eventService;
        
        private Event editedEvent;

        public EventEnrollmentPresenter(IEventEnrollmentView view)
            : this(view, null)
        {
        }

        public EventEnrollmentPresenter(IEventEnrollmentView view, Event editedEvent)
            : base(view)
        {
            this.editedEvent = editedEvent;
            this.eventService = new EventService();
        }

        public void InitView()
        {
            if (editedEvent != null)
            {
                View.SetEventTitle(editedEvent.Title);
                View.SetEventDate(editedEvent.Date);
                View.SetEventNotes(editedEvent.Notes);
                View.SetEventVisibility(VisibilityTypeExtensions.FromValue(editedEvent.Visibility));
                View.SetEventFontColor(editedEvent.FontColor.FromHex(Color.White));
                View.SetEventBackColor(editedEvent.BackColor.FromHex(Color.Red));
                View.SetRemoveButtonVisible(true);
            }
            else
            {
                View.SetRemoveButtonVisible(false);
            }
        }

        public void OnCancel()
        {
            editedEvent = null;
            View.EventResult = null;
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
                    Visibility = (int)View.GetEventVisibility(),
                    BackColor = View.GetEventBackColor().ToHex(),
                    FontColor = View.GetEventFontColor().ToHex()
                };
                if (editedEvent != null)
                {
                    newEvent.Id = editedEvent.Id;
                }
                return eventService.AddEvent(newEvent);
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                var newEvent = t.Result;
                if (newEvent != null)
                {
                    View.EventResult = new EventResult(newEvent);
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

        public void OnRemoveEvent()
        {
            var task = new Task(() =>
            {
                if (View.ShowBinaryQuestion("Deseja apagar este evento?"))
                {
                    View.ShowWaitingPanel("Apagando evento...");
                    eventService.RemoveEventById(editedEvent.Id);
                }
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                View.EventResult = new EventResult(editedEvent, true);
                View.SetDialogResult(DialogResult.OK);
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

        public void OnSelectEventBackColor()
        {
            var eventColor = View.SelectEventBackColor();
            if (eventColor.HasValue)
            {
                View.SetEventBackColor(eventColor.Value);
            }
        }

        public void OnSelectEventFontColor()
        {
            var color = View.SelectEventFontColor();
            if (color.HasValue)
            {
                View.SetEventFontColor(color.Value);
            }
        }
    }
}
