namespace TadManagementTool.Presenter
{
    public interface INewsletterUserListPresenter : IPresenter
    {
        void OnAddNewsletterUser();
        void OnExportToExcel();
        void OnRemoveNewsletterUser();
        void OnSelectNewsletterUserView();
    }
}
