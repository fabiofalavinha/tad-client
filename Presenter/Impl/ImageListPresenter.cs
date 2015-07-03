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
            DoLoadImageList();
        }

        private void DoLoadImageList()
        {
            var task = new Task<IList<CarouselImage>>(() =>
            {
                var carouselImageService = new CarouselImageService();
                return carouselImageService.GetImages();
            });
            task.ContinueWith(t =>
            {
                View.SetImageList(t.Result.Select(i => new ImageCarouselViewItem(i)).ToArray());
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao carregar as imagens. Tente repetir a operação. {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnRemove()
        {
            var task = new Task<ImageCarouselViewItem>(() =>
            {
                var selected = View.GetSelectedImage();
                if (selected != null)
                {
                    if (View.ShowBinaryQuestion("Deseja apagar esta imagem?"))
                    {
                        View.ShowWaitingPanel("Removendo imagem...");
                        var carouselImageService = new CarouselImageService();
                        carouselImageService.RemoveImage(selected.Wrapper);
                    }
                }
                return selected;
            });
            task.ContinueWith(t =>
            {
                var image = t.Result;
                if (image != null)
                {
                    View.HideWaitingPanel();
                    View.RemoveImageItem(image);
                }
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

        public void OnNewUpload()
        {
            View.OpenNewUploadView();
            DoLoadImageList();
        }

        public void OnImageItemSelected(ImageCarouselViewItem imageCarouselViewItem)
        {
            View.SetImageItemSelected(imageCarouselViewItem);
        }
    }
}
