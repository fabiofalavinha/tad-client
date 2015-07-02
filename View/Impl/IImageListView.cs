using System.Collections.Generic;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IImageListView : IControlView
    {
        void SetImageList(IList<ImageCarouselViewItem> list);
        void OpenNewUploadView();
    }
}
