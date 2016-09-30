using System;
using System.Collections.Generic;
using TadManagementTool.Model;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface ICalendarView : IControlView
    {
        Event OpenEnrollmentEventView();
        EventResult OpenEnrollmentEventView(Event targetEvent);
        void SetEvents(IList<Event> events);
        void AddEvent(Event newEvent);
        void SetCurrentCalendarDate(DateTime today);
    }
}
