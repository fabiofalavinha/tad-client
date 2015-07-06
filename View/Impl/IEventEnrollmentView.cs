using System;
using System.Collections.Generic;
using System.Drawing;
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
        Color? SelectEventBackColor();
        Color? SelectEventFontColor();
        Color GetEventBackColor();
        Color GetEventFontColor();
        bool ShowBinaryQuestion(string message);
        void SetEventTitle(string title);
        void SetEventDate(DateTime date);
        void SetEventNotes(string notes);
        void SetEventVisibility(VisibilityType visibilityType);
        void SetRemoveButtonVisible(bool visible);
        void SetEventBackColor(Color color);
        void SetEventFontColor(Color color);
    }
}
