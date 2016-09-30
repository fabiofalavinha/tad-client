using Calendar.NET;
using System;
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
            if (!string.IsNullOrWhiteSpace(targetEvent.BackColor))
            {
                EventColor = targetEvent.BackColor.FromHex();
            }
            if (!string.IsNullOrWhiteSpace(targetEvent.FontColor))
            {
                EventTextColor = targetEvent.FontColor.FromHex();
            }
            EventText = string.Concat(TargetEvent.Title, Environment.NewLine, TargetEvent.Notes);
        }
    }
}
