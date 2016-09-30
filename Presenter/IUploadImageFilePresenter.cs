namespace TadManagementTool.Presenter
{
    public interface IUploadImageFilePresenter : IPresenter
    {
        void OnSelectImageFiles();
        void OnRemoveSelectedImageFiles();
        void OnStartUpload();
    }
}
