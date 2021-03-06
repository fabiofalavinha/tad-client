﻿using Calendar.NET;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class CalendarUserControl : UserControl, ICalendarView
    {
        private readonly IMainView parentView;
        private readonly ICalendarPresenter presenter;

        public CalendarUserControl(IMainView parentView)
        {
            InitializeComponent();
            calendarControl.EventDetailsCallback = new CustomEventDetailsCallback(this);
            this.parentView = parentView;
            presenter = new CalendarPresenter(this);
        }

        private void CalendarUserControl_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        public void ShowWarningMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowWarningMessage), message);
                return;
            }
            MessageBox.Show(message, "TAD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowWaitingPanel(string message = null)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowWaitingPanel), message);
                return;
            }
            if (string.IsNullOrWhiteSpace(message))
            {
                message = "Processando...";
            }
            modalWaitingPanel.Show(message);
        }

        public void HideWaitingPanel()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(HideWaitingPanel));
                return;
            }
            modalWaitingPanel.Hide();
        }

        public void ShowErrorMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowErrorMessage), message);
                return;
            }
            MessageBox.Show(message, "TAD", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SetEvents(IList<Event> events)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<Event>>(SetEvents), events);
                return;
            }
            foreach (var eventItem in events)
            {
                DoAddEvent(eventItem);
            }
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            presenter.OnAddEvent();
        }

        public Event OpenEnrollmentEventView()
        {
            if (InvokeRequired)
            {
                return (Event)Invoke(new Func<Event>(OpenEnrollmentEventView));
            }
            using (var eventForm = new EventForm())
            {
                if (eventForm.ShowDialog() == DialogResult.OK)
                {
                    return eventForm.EventResult.Target;
                }
            }
            return null;
        }

        public EventResult OpenEnrollmentEventView(Event targetEvent)
        {
            if (InvokeRequired)
            {
                return (EventResult)Invoke(new Func<Event, EventResult>(OpenEnrollmentEventView), targetEvent);
            }
            using (var eventForm = new EventForm(targetEvent))
            {
                if (eventForm.ShowDialog() == DialogResult.OK)
                {
                    return eventForm.EventResult;
                }
            }
            return null;
        }

        public void AddEvent(Event newEvent)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Event>(AddEvent), newEvent);
                return;
            }
            DoAddEvent(newEvent);
        }

        private void DoAddEvent(Event newEvent)
        {
            calendarControl.AddEvent(new TadEvent(newEvent));
        }

        public void SetCurrentCalendarDate(DateTime now)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DateTime>(SetCurrentCalendarDate), now);
                return;
            }
            calendarControl.CalendarDate = now;
        }
    }

    class CustomEventDetailsCallback : IEventDetailsCallback
    {
        private readonly ICalendarView view;

        public CustomEventDetailsCallback(ICalendarView view)
        {
            this.view = view;
        }

        public IEvent ShowEvent(IEvent eventDetails)
        {
            if (eventDetails != null)
            {
                var tadEvent = eventDetails as TadEvent;
                if (tadEvent != null)
                {
                    var eventResult = view.OpenEnrollmentEventView(tadEvent.TargetEvent);
                    if (eventResult != null)
                    {
                        var newTadEvent = new TadEvent(eventResult.Target);
                        newTadEvent.Enabled = !eventResult.Removed;
                        return newTadEvent;
                    }
                }
            }
            return null;
        }
    }
}
