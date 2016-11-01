using System.Collections.Generic;
using TadManagementTool.Model;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IConsecrationEnrollmentView : IDialogView
    {
        void SetElementList(IList<ElementViewItem> elements);
        void SetCommunicationMessage(CommunicationMessage message);
        void SetCollaboratorList(IList<CollaboratorViewItem> list);
        void SetElementUnitList(IList<ElementUnitViewItem> list);
        IList<ElementViewItem> GetElements();
        string GetMailContent();
    }
}
