using System;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View;

namespace TadManagementTool
{
    public partial class UserChangePasswordForm : Form, IUserChangePasswordView
    {
        private readonly IUserChangePasswordPresenter presenter;

        public UserChangePasswordForm(User user)
        {
            InitializeComponent();
            this.presenter = new UserChangePasswordPresenter(this, user);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            presenter.OnOk();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            presenter.OnCancel();
        }

        private void UserChangePasswordForm_Load(object sender, EventArgs e)
        {
            presenter.InitView();
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

        public void CloseView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(CloseView));
                return;
            }
            Close();
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

        public string GetCurrentPassword()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetCurrentPassword));
            }
            return currentPasswordTextBox.Text;
        }

        public string GetNewPassword()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetNewPassword));
            }
            return newPasswordTextBox.Text;
        }

        public string GetConfirmNewPassword()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetConfirmNewPassword));
            }
            return confirmNewPasswordTextBox.Text;
        }
    }
}
