using System;
using System.Windows.Forms;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.Properties;
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
            var menuActionViewString = e.Node.Tag.ToString();
            var menuActionView = Activator.CreateInstance(Type.GetType(menuActionViewString)) as IMenuActionView;
            if (menuActionView != null)
            {
                presenter.OnMenuItemSelect(menuActionView);
            }
            else
            {
                ShowWarningMessage(string.Format("Não foi possível abrir a tela [{0}]", menuActionViewString));
            }
        }

        public void OpenCollaboratorView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenCollaboratorView));
                return;
            }
            splitContainer.Panel2.Controls.Clear();
            var userControl = new ListCollaboratorUserControl(this);
            userControl.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Add(userControl);
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
            splitContainer.Panel2.Controls.Clear();
            var userControl = new CalendarUserControl(this);
            userControl.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Add(userControl);
        }

        public void OpenPostListView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenPostListView));
                return;
            }
            splitContainer.Panel2.Controls.Clear();
            var userControl = new PostListUserControl(this);
            userControl.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Add(userControl);
        }

        public void OpenImageListView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenImageListView));
                return;
            }
            splitContainer.Panel2.Controls.Clear();
            var userControl = new ImageListUserControl(this);
            userControl.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Add(userControl);
        }
    }
}
