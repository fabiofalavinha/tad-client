using System.Collections.Generic;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IImageListView : IControlView
    {
        ImageCarouselViewItem GetSelectedImage();
        bool ShowBinaryQuestion(string message);
        void SetImageList(IList<ImageCarouselViewItem> list);
        void OpenNewUploadView();
        void SetImageItemSelected(ImageCarouselViewItem imageCarouselViewItem);
        void RemoveImageItem(ImageCarouselViewItem imageCarouselViewItem);
    }
}
