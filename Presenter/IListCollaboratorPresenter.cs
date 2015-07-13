using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TadManagementTool.Presenter
{
    public interface IListCollaboratorPresenter : IPresenter
    {
        void OnRemoveCollaborator();
        void OnNewCollaborator();
        void OnViewCollaboratorDetails();
        void OnExportToExcel();
        void OnSortCollaboratorList(string propertyName, SortOrder sortOrder);
    }
}
