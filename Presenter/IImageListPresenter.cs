using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
