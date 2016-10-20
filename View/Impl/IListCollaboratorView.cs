using System.Collections.Generic;
using TadManagementTool.Model;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IListCollaboratorView : IControlView
    {
        IList<CollaboratorViewItem> GetCollaboratorList();
        CollaboratorViewItem GetCollaboratorSelected();
        bool ShowBinaryQuestion(string message);
        string SelectFilePathToSaveExcelFile();
        bool IsActiveFilterChecked();
        bool IsNonCollaboratorFilterChecked();
        void SetCollaboratorList(IList<CollaboratorViewItem> list, CollaboratorPreferences collaboratorPreferences);
        void OpenCollaboratorView();
        void OpenCollaboratorView(Collaborator collaborator);
        void SetActiveCollaboratorCount(int count);
        void ShowSuccessMessage(string message);
    }
}
