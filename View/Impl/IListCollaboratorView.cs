using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        bool GetFilterActive();
        void SetCollaboratorList(IList<CollaboratorViewItem> list);
        void OpenCollaboratorView();
        void OpenCollaboratorView(Collaborator collaborator);
        void SetActiveCollaboratorCount(int count);
        void ShowSuccessMessage(string message);
    }
}
