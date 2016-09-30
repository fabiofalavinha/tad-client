using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;

namespace TadManagementTool
{
    public partial class NewsletterListUserControl : UserControl, INewsletterUserViewItem
    {
        private readonly IMainView parentView;
        private readonly INewsletterUserListPresenter presenter;

        public NewsletterListUserControl(IMainView parentView)
        {
            InitializeComponent();
            newsletterDataGridView.AutoGenerateColumns = false;
            this.parentView = parentView;
            presenter = new NewsletterUserListPresenter(this);
        }

        private void NewsletterListUserControl_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            presenter.OnExportToExcel();
        }

        private void addNewsletterUserButton_Click(object sender, EventArgs e)
        {
            presenter.OnNewNewsletterUser();
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

        public void ShowErrorMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowErrorMessage), message);
                return;
            }
            MessageBox.Show(message, "TAD", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void SetNewsletterUserList(IList<NewsletterUserViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<NewsletterUserViewItem>>(SetNewsletterUserList), list);
                return;
            }
            bindingSource.DataSource = list;
            newsletterDataGridView.DataSource = bindingSource;
            bindingSource.ResetBindings(false);
            newsletterDataGridView.ClearSelection();
            newsletterDataGridView.AutoResizeColumns();
        }

        private void removeNewsletterUserButton_Click(object sender, EventArgs e)
        {
            presenter.OnRemoveNewsletterUser();
        }

        public bool ShowBinaryQuestion(string message)
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<string, bool>(ShowBinaryQuestion), message);
            }
            return MessageBox.Show(message, "TAD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public NewsletterUserViewItem GetNewsletterUserSelected()
        {
            if (InvokeRequired)
            {
                return (NewsletterUserViewItem)Invoke(new Func<NewsletterUserViewItem>(GetNewsletterUserSelected));
            }
            if (newsletterDataGridView.SelectedRows.Count > 0)
            {
                return (NewsletterUserViewItem)newsletterDataGridView.SelectedRows[0].DataBoundItem;
            }
            return null;
        }

        public string SelectFilePathToSaveExcelFile()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(SelectFilePathToSaveExcelFile));
            }
            var dialogResult = exportToExcelSaveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                return exportToExcelSaveFileDialog.FileName;
            }
            return null;
        }

        public IList<NewsletterUserViewItem> GetNewsletterUserList()
        {
            if (InvokeRequired)
            {
                return (IList<NewsletterUserViewItem>)Invoke(new Func<IList<NewsletterUserViewItem>>(GetNewsletterUserList));
            }
            return newsletterDataGridView.Rows.Cast<DataGridViewRow>().Select(r => (NewsletterUserViewItem)r.DataBoundItem).ToArray();
        }

        public void ShowSuccessMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowSuccessMessage), message);
                return;
            }
            MessageBox.Show(message, "TAD", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
