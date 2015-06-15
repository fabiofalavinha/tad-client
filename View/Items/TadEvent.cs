using Calendar.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class TadEvent : CustomEvent
    {
        public Event TargetEvent { get; private set; }

        public TadEvent(Event targetEvent)
        {
            if (targetEvent == null)
            {
                throw new ArgumentNullException("targetEvent");
            }
            Enabled = true;
            TargetEvent = targetEvent;
            Date = targetEvent.Date;
            EventText = string.Concat(TargetEvent.Title, Environment.NewLine, TargetEvent.Notes);
        }
    }
}
