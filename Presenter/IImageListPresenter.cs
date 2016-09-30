using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter
{
    public interface IImageListPresenter : IPresenter
    {
        void OnRemove();
        void OnNewUpload();
        void OnImageItemSelected(ImageCarouselViewItem imageCarouselViewItem);
    }
}
