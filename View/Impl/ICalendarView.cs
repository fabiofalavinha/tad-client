using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface ICalendarView : IControlView
    {
        DateTime GetMonthDaySelected();
        Event OpenEnrollmentEventView();
        EventResult OpenEnrollmentEventView(Event targetEvent);
        void SetEvents(IList<Event> events);
        void AddEvent(Event newEvent);
    }
}
