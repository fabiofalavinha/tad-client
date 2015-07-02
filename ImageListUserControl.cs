using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TadManagementTool.View.Impl;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.Model;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class ImageListUserControl : UserControl, IImageListView
    {
        private readonly IMainView parentView;
        private readonly IImageListPresenter presenter;

        public ImageListUserControl(IMainView parentView)
        {
            InitializeComponent();
            this.parentView = parentView;
            this.presenter = new ImageListPresenter(this);
        }

        private void ImageListUserControl_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        private void removeImageButton_Click(object sender, EventArgs e)
        {
            presenter.OnRemove();
        }

        private void uploadImageButton_Click(object sender, EventArgs e)
        {
            presenter.OnNewUpload();
        }

        public void ShowWarningMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowWarningMessage), message);
                return;
            }
            MessageBox.Show(message, "TAD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowWaitingPanel(string message = null)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowWaitingPanel), message);
                return;
            }
            if (string.IsNullOrWhiteSpace(message))
            {
                message = "Processando...";
            }
            modalWaitingPanel.Show(message);
        }

        public void HideWaitingPanel()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(HideWaitingPanel));
                return;
            }
            modalWaitingPanel.Hide();
        }

        public void ShowErrorMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowErrorMessage), message);
                return;
            }
            MessageBox.Show(message, "TAD", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SetImageList(IList<ImageCarouselViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<ImageCarouselViewItem>>(SetImageList), list);
                return;
            }
            imageFlowLayoutPanel.Controls.Clear();
            imageFlowLayoutPanel.Controls.AddRange(list.Select(i => new ImageItemUserControl(i)).ToArray());
        }

        public void OpenNewUploadView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenNewUploadView));
                return;
            }
            using (var form = new UploadImageForm()) 
            {

            }
        }
    }
}
