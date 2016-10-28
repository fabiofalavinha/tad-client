using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;

namespace TadManagementTool
{
    public partial class UploadImageForm : AbstractForm, IUploadImageFileView
    {
        private readonly IUploadImageFilePresenter presenter;

        public UploadImageForm()
        {
            InitializeComponent();
            this.presenter = new UploadImageFilePresenter(this);
        }

        private void UploadImageForm_Load(object sender, EventArgs e)
        {
            presenter.InitView();
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
        
        private void addButton_Click(object sender, EventArgs e)
        {
            presenter.OnSelectImageFiles();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            presenter.OnRemoveSelectedImageFiles();
        }

        private void startUploadButton_Click(object sender, EventArgs e)
        {
            presenter.OnStartUpload();
        }

        public IList<FileInfo> SelectImageFiles()
        {
            if (InvokeRequired)
            {
                return (IList<FileInfo>)Invoke(new Func<IList<FileInfo>>(SelectImageFiles));
            }

            var dialogResult = imageOpenFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                return imageOpenFileDialog.FileNames.Select(p => new FileInfo(p)).ToArray();
            }
            return new FileInfo[] {};
        }

        public IList<FileInfo> GetSelectedImageFiles()
        {
            if (InvokeRequired)
            {
                return (IList<FileInfo>)Invoke(new Func<IList<FileInfo>>(GetSelectedImageFiles));
            }
            return fileListBox.Items.Cast<string>().Select(p => new FileInfo(p)).ToArray();
        }

        public void RemoveSelectedImageFile(FileInfo imageFileInfo)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<FileInfo>(RemoveSelectedImageFile), imageFileInfo);
                return;
            }
            fileListBox.Items.Remove(imageFileInfo.FullName);
        }

        public void SetSelectedImageFiles(IList<FileInfo> imageFiles)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FileInfo>>(SetSelectedImageFiles), imageFiles);
                return;
            }
            fileListBox.Items.Clear();
            fileListBox.Items.AddRange(imageFiles.Select(i => i.FullName).ToArray());
        }
    }
}
 