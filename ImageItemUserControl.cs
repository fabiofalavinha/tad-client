using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TadManagementTool.View.Items;
using System.Net;
using System.IO;

namespace TadManagementTool
{
    public partial class ImageItemUserControl : UserControl
    {
        public ImageCarouselViewItem Wrapper { get; private set; }

        public event EventHandler<ImageClickedEventArgs> ImageClicked;

        public ImageItemUserControl(ImageCarouselViewItem viewItem)
        {
            InitializeComponent();
            Wrapper = viewItem;
        }

        private void ImageItemUserControl_Load(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(Wrapper);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            modalWaitingPanel.Show("Carregando...");
            var viewItem = (ImageCarouselViewItem)e.Argument;
            using (var webClient = new CustomWebClient())
            {
                try
                {
                    webClient.DownloadProgressChanged += (s, ee) => imageProgressBar.Value = ee.ProgressPercentage;
                    e.Result = webClient.DownloadData(viewItem.ImageUrl);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                }
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Image image;
            using (var memoryStream = new MemoryStream((byte[])e.Result))
            {
                image = Image.FromStream(memoryStream);
            }
            imageProgressBar.Visible = false;
            imageContainerPanel.BackgroundImageLayout = ImageLayout.Zoom;
            imageContainerPanel.BackgroundImage = image;
            modalWaitingPanel.Hide();
        }

        private class CustomWebClient : WebClient
        {
            private const int DefaultTimeout = 30000;

            protected override WebRequest GetWebRequest(Uri address)
            {
                var webRequest = base.GetWebRequest(address);
                webRequest.Timeout = DefaultTimeout;
                return webRequest;
            }
        }

        private void ImageItemUserControl_Click(object sender, EventArgs e)
        {
            OnImageClicked();
        }

        private void OnImageClicked()
        {
            if (ImageClicked != null)
            {
                ImageClicked(this, new ImageClickedEventArgs(Wrapper));
            }
        }

        private void imageContainerPanel_Click(object sender, EventArgs e)
        {
            OnImageClicked();
        }
    }

    public class ImageClickedEventArgs : EventArgs
    {
        public ImageCarouselViewItem Image { get; private set; }

        public ImageClickedEventArgs(ImageCarouselViewItem image)
        {
            Image = image;
        }
    }
}
