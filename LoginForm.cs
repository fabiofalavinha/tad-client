using System;
using System.Windows.Forms;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.Properties;
using TadManagementTool.View.Impl;

namespace TadManagementTool
{
    public partial class LoginForm : Form, ILoginView
    {
        private readonly ILoginPresenter presenter;

        public LoginForm()
        {
            InitializeComponent();
            Settings.Default.Reload();
            presenter = new LoginPresenter(this);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            presenter.OnCancel();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            presenter.OnSingIn();
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

        public string GetPassword()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetPassword));
            }
            return passwordTextBox.Text;
        }

        public string GetUserName()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetUserName));
            }
            return emailTextBox.Text;
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

        public void StoreLastUserName(string lastUserName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(StoreLastUserName), lastUserName);
                return;
            }
            Settings.Default.LastUser = lastUserName;
            Settings.Default.Save();
        }

        public string GetLastUserStored()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetLastUserStored));
            }
            return Settings.Default.LastUser;
        }

        public void SetUserName(string userName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetUserName), userName);
                return;
            }
            emailTextBox.Text = userName;
        }

        public void SetPasswordFocus()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(SetPasswordFocus));
                return;
            }
            ActiveControl = passwordTextBox;
            passwordTextBox.Focus();
        }
    }
}
