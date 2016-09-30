using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class PostListUserControl : UserControl, IPostListView
    {
        private readonly IMainView parentView;
        private readonly IPostListPresenter presenter;

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

        public PostListUserControl(IMainView parentView)
        {
            InitializeComponent();
            postDataGridView.AutoGenerateColumns = false;
            this.parentView = parentView;
            this.presenter = new PostListPresenter(this);
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

        private void unPublishPostButton_Click(object sender, EventArgs e)
        {
            presenter.OnUnPublishPost();
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

        private void postDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            presenter.OnViewPostDetails();
        }

        private void postDataGridView_DragDrop(object sender, DragEventArgs e)
        {
            var clientPoint = postDataGridView.PointToClient(new Point(e.X, e.Y));

            rowIndexOfItemUnderMouseToDrop = postDataGridView.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect == DragDropEffects.Move)
            {
                var rowToMove = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                presenter.OnOrderPost(new PostOrderViewItem(rowIndexFromMouseDown, rowIndexOfItemUnderMouseToDrop, (PostViewItem)rowToMove.DataBoundItem));
            }
        }

        private void postDataGridView_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void postDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndexFromMouseDown = postDataGridView.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                var dragSize = SystemInformation.DragSize;
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            }
            else
            {
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }

        private void postDataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    postDataGridView.DoDragDrop(postDataGridView.Rows[rowIndexFromMouseDown], DragDropEffects.Move);
                }
            }
        }

        public IList<PostViewItem> GetPostList()
        {
            if (InvokeRequired)
            {
                return (IList<PostViewItem>)Invoke(new Func<IList<PostViewItem>>(GetPostList));
            }
            return postDataGridView.Rows.Cast<DataGridViewRow>().Select(r => (PostViewItem)r.DataBoundItem).ToArray();
        }

        private void orderPostListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            postDataGridView.AllowDrop = orderPostListCheckBox.Checked;
            presenter.OnEnablePostListOrder();
        }

        public bool IsPostListOrderOptionChecked()
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<bool>(IsPostListOrderOptionChecked));
            }
            return orderPostListCheckBox.Checked;
        }

        public void SetPostListSaveOrderButtonVisible(bool visible)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetPostListSaveOrderButtonVisible), visible);
                return;
            }
            saveOrderListButton.Visible = visible;
        }

        private void saveOrderListButton_Click(object sender, EventArgs e)
        {
            presenter.OnSavePostListOrder();
        }

        public void SetOrderListOptionChecked(bool value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetOrderListOptionChecked), value);
                return;
            }
            orderPostListCheckBox.Checked = false;
        }

        private void postDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            presenter.OnPostSelected();
        }

        public void SetUnPublishButtonVisible(bool visible)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetUnPublishButtonVisible), visible);
                return;
            }
            unPublishPostButton.Visible = visible;
        }

        private void postDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData & Keys.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }
    }
}
