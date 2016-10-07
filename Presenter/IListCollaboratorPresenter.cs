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
        void OnSearchCollaborators();
        void OnColumnReOrder(string name, int index);
    }
}
