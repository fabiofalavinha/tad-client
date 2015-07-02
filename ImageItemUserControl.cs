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
        private readonly ImageCarouselViewItem viewItem;
            
        public ImageItemUserControl(ImageCarouselViewItem viewItem)
        {
            InitializeComponent();
            this.viewItem = viewItem;
        }

        private void ImageItemUserControl_Load(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(viewItem);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            modalWaitingPanel.Show("Carregando...");
            var viewItem = (ImageCarouselViewItem)e.Argument;
            using (var webClient = new CustomWebClient())
            {
                webClient.DownloadProgressChanged += (s, ee) => imageProgressBar.Value = ee.ProgressPercentage;
                e.Result = webClient.DownloadData(viewItem.ImageUrl);
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
    }
}
