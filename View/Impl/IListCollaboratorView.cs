using System.Collections.Generic;
using TadManagementTool.Model;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IListCollaboratorView : IControlView
    {
        IList<Items.CollaboratorViewItem> GetCollaboratorList();
        CollaboratorViewItem GetCollaboratorSelected();
        bool ShowBinaryQuestion(string message);
        string SelectFilePathToSaveExcelFile();
        bool IsActiveFilterChecked();
        bool IsNonCollaboratorFilterChecked();
        void SetCollaboratorList(IList<Items.CollaboratorViewItem> list, CollaboratorPreferences collaboratorPreferences);
        void OpenCollaboratorView();
        void OpenCollaboratorView(Model.Collaborator collaborator);
        void SetActiveCollaboratorCount(int count);
        void ShowSuccessMessage(string message);
    }
}
