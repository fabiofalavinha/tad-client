using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;
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
            imageFlowLayoutPanel.Controls.AddRange(list.Select(i =>
            {
                var control = new ImageItemUserControl(i);
                control.ImageClicked += imageItemUserControl_ImageClicked;
                return control;
            }).ToArray());
        }

        private void imageItemUserControl_ImageClicked(object sender, ImageClickedEventArgs e)
        {
            presenter.OnImageItemSelected(e.Image);
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
                form.ShowDialog();
            }
        }

        public void SetImageItemSelected(ImageCarouselViewItem imageCarouselViewItem)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<ImageCarouselViewItem>(SetImageItemSelected), imageCarouselViewItem);
                return;
            }
            imageFlowLayoutPanel.Controls.Cast<ImageItemUserControl>().ToList().ForEach(i =>
            {
                if (i.Wrapper.Equals(imageCarouselViewItem))
                {
                    i.Wrapper.Select();
                    i.BackColor = Color.LightBlue;
                }
                else
                {
                    i.Wrapper.Unselect();
                    i.BackColor = Color.White;
                }
            });
        }

        public ImageCarouselViewItem GetSelectedImage()
        {
            if (InvokeRequired)
            {
                return (ImageCarouselViewItem)Invoke(new Func<ImageCarouselViewItem>(GetSelectedImage));
            }
            var found = imageFlowLayoutPanel.Controls.Cast<ImageItemUserControl>().SingleOrDefault(i => i.Wrapper.IsSelected);
            if (found != null)
            {
                return found.Wrapper;
            }
            return null;
        }


        public void RemoveImageItem(ImageCarouselViewItem imageCarouselViewItem)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<ImageCarouselViewItem>(RemoveImageItem), imageCarouselViewItem);
                return;
            }
            var found = imageFlowLayoutPanel.Controls.Cast<ImageItemUserControl>().SingleOrDefault(i => i.Wrapper.Equals(imageCarouselViewItem));
            if (found != null)
            {
                imageFlowLayoutPanel.Controls.Remove(found);
            }
        }

        public bool ShowBinaryQuestion(string message)
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<string, bool>(ShowBinaryQuestion), message);
            }
            return MessageBox.Show(message, "TAD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
