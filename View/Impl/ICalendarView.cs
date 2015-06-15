using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.View.Impl
{
    public interface ICalendarView : IControlView
    {
        DateTime GetMonthDaySelected();
        Event OpenEnrollmentEventView();
        void SetEvents(IList<Event> events);
        void AddEvent(Event newEvent);
    }
}
