using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class ImageListPresenter : AbstractControlPresenter<IImageListView>, IImageListPresenter
    {
        public ImageListPresenter(IImageListView view)
            : base(view)
        {
        }

        public void InitView()
        {
            var task = new Task<IList<CarouselImage>>(() =>
            {
                View.ShowWaitingPanel("Carregando imagens...");
                var carouselImageService = new CarouselImageService();
                return carouselImageService.GetImages();
            });
            task.ContinueWith(t =>
            {
                View.SetImageList(t.Result.Select(i => new ImageCarouselViewItem(i)).ToArray());
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao carregar as imagens. Tente repetir a operação. {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnRemove()
        {
        }

        public void OnNewUpload()
        {
            View.OpenNewUploadView();
        }
    }
}
