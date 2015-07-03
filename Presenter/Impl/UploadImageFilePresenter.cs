using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class UploadImageFilePresenter : AbstractDialogPresenter<IUploadImageFileView>, IUploadImageFilePresenter
    {
        public UploadImageFilePresenter(IUploadImageFileView view)
            : base(view)
        {
        }

        public void InitView()
        {
            // do nothing
        }

        public void OnSelectImageFiles()
        {
            var imageFiles = View.SelectImageFiles();
            View.SetSelectedImageFiles(imageFiles);
        }

        public void OnRemoveSelectedImageFiles()
        {
            View.GetSelectedImageFiles().ToList().ForEach(f => View.RemoveSelectedImageFile(f));
        }

        public void OnStartUpload()
        {
            var task = new Task(() =>
            {
                var selectedImageFiles = View.GetSelectedImageFiles();
                if (!selectedImageFiles.Any())
                {
                    View.ShowWarningMessage("Selecione alguma imagem para realizar o upload");
                    return;
                }
                View.ShowWaitingPanel("Uploading...");
                var carouselImageService = new CarouselImageService();
                carouselImageService.UploadImages(selectedImageFiles);
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao fazer upload das imagens. Tente repetir a operação. {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                View.SetDialogResult(DialogResult.OK);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }
    }
}
