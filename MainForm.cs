using System;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View;
using TadManagementTool.View.Impl;

namespace TadManagementTool
{
    public partial class MainForm : Form, IMainView
    {
        private readonly IMainPresenter presenter;

        public MainForm()
        {
            InitializeComponent();
            menuTreeView.SelectedNode = menuTreeView.Nodes[0];
            menuTreeView.ExpandAll();
            presenter = new MainPresenter(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
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

        public void CloseView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(CloseView));
                return;
            }
            Close();
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DialogResult>(SetDialogResult), dialogResult);
                return;
            }
            DialogResult = dialogResult;
        }

        private void menuTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tag = e.Node.Tag;
            if (tag != null)
            {
                presenter.OnMenuItemSelect(tag.ToString());
            }
        }

        public void OpenCollaboratorView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenCollaboratorView));
                return;
            }
            DoLoadMainControl(new ListCollaboratorUserControl(this));
        }

        public void ShowControlView(IControlView controlView)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IControlView>(ShowControlView), controlView);
                return;
            }
            splitContainer.Panel2.Controls.Clear();
            splitContainer.Panel2.Controls.Add((UserControl)controlView);
        }

        public void OpenCalendarView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenCalendarView));
                return;
            }
            DoLoadMainControl(new CalendarUserControl(this));
        }

        public void OpenPostListView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenPostListView));
                return;
            }
            DoLoadMainControl(new PostListUserControl(this));
        }

        public void OpenImageListView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenImageListView));
                return;
            }
            DoLoadMainControl(new ImageListUserControl(this));
        }

        private void alterarSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.OnUserChangePassword();
        }

        public void OpenUserChangePasswordView(User user)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<User>(OpenUserChangePasswordView), user);
                return;
            }
            using (var form = new UserChangePasswordForm(user))
            {
                form.ShowDialog();
            }
        }

        public void OpenCollaboratorBirthDaysView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenCollaboratorBirthDaysView));
                return;
            }
            DoLoadMainControl(new CollaboratorBirthDaysUserControl());
        }

        private void DoLoadMainControl(UserControl userControl)
        {
            splitContainer.Panel2.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Add(userControl);
        }

        public void OpenFinancialReferenceListView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenFinancialReferenceListView));
                return;
            }
            DoLoadMainControl(new FinancialReferenceListUserControl(this));
        }

        public void OpenFinancialEntryListView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenFinancialEntryListView));
                return;
            }
            DoLoadMainControl(new FinancialEntryListUserControl(this));
        }
    }
}
