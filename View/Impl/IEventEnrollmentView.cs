using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.View.Impl
{
    public interface IEventEnrollmentView : IDialogView
    {
        Event EventResult { get; set; }
        string GetEventTitle();
        DateTime GetEventDate();
        string GetEventNotes();
        VisibilityType GetEventVisibility();
    }
}
