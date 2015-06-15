using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IEventEnrollmentView : IDialogView
    {
        EventResult EventResult { get; set; }
        string GetEventTitle();
        DateTime GetEventDate();
        string GetEventNotes();
        VisibilityType GetEventVisibility();
        bool ShowBinaryQuestion(string message);
        void SetEventTitle(string title);
        void SetEventDate(DateTime date);
        void SetEventNotes(string notes);
        void SetEventVisibility(VisibilityType visibilityType);
        void SetRemoveButtonVisible(bool visible);
    }
}
