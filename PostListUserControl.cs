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
using TadManagementTool.View.Items;
using TadManagementTool.Model;

namespace TadManagementTool
{
    public partial class PostListUserControl : UserControl, IListPostView
    {
        private readonly IMainView parentView;
        private readonly IListPostPresenter presenter;

        public PostListUserControl(IMainView parentView)
        {
            InitializeComponent();
            postDataGridView.AutoGenerateColumns = false;
            this.parentView = parentView;
            this.presenter = new ListPostPresenter(this);
        }

        private void PostListUserControl_Load(object sender, EventArgs e)
        {
            presenter.InitView();
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

        private void publishedButton_Click(object sender, EventArgs e)
        {
            presenter.OnPublishPost();
        }

        private void viewDetailsButton_Click(object sender, EventArgs e)
        {
            presenter.OnViewPostDetails();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            presenter.OnRemovePost();
        }

        public void SetPostList(IList<PostViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<PostViewItem>>(SetPostList), list);
                return;
            }
            postBindingSource.DataSource = list;
            postDataGridView.DataSource = postBindingSource;
            postBindingSource.ResetBindings(false);
            postDataGridView.ClearSelection();
            postDataGridView.AutoResizeColumns();
        }

        private void newPostButton_Click(object sender, EventArgs e)
        {
            presenter.OnNewPost();
        }

        public void OpenNewPostView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenNewPostView));
                return;
            }
            parentView.ShowControlView(new Editor(parentView, null)
            {
                Dock = DockStyle.Fill
            });
        }

        public void OpenEditPostView(Post post)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Post>(OpenEditPostView), post);
                return;
            }
            parentView.ShowControlView(new Editor(parentView, post)
            {
                Dock = DockStyle.Fill
            });
        }

        public PostViewItem GetPostSelected()
        {
            if (InvokeRequired)
            {
                return (PostViewItem)Invoke(new Func<PostViewItem>(GetPostSelected));
            }
            var row = postDataGridView.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            if (row != null)
            {
                return (PostViewItem)row.DataBoundItem;
            }
            return null;
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
