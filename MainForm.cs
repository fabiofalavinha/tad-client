﻿using System;
using System.Linq;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View;
using TadManagementTool.View.Impl;

namespace TadManagementTool
{
    public partial class MainForm : AbstractForm, IMainView
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

        public void ConfigureMenuPermissions()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(ConfigureMenuPermissions));
                return;
            }
            foreach (TreeNode node in menuTreeView.Nodes.Cast<TreeNode>().ToArray())
            {
                if (node.Tag != null)
                {
                    var canAccess = presenter.OnMenuItemAccess(node.Tag.ToString());
                    if (!canAccess)
                    {
                        menuTreeView.Nodes.Remove(node);
                    }
                }
            }
        }

        public void OpenNewsletterView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenNewsletterView));
                return;
            }
            DoLoadMainControl(new NewsletterListUserControl(this));
        }

        public void SetApplicationVersion(string versionText)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetApplicationVersion), versionText);
                return;
            }
            Text = $"TAD - v{versionText}";
        }

        public void OpenConsecrationView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenConsecrationView));
                return;
            }
            DoLoadMainControl(new ConsecrationHistoryListUserControl(this));
        }
    }
}
