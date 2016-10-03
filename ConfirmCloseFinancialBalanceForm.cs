using System;
using System.Windows.Forms;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;

namespace TadManagementTool
{
    public partial class ConfirmCloseFinancialBalanceForm : Form, IConfirmCloseFinancialBalanceView
    {
        private readonly IConfirmCloseFinancialBalancePresenter presenter;

        public ConfirmCloseFinancialBalanceForm()
        {
            InitializeComponent();
            presenter = new ConfirmCloseFinancialBalancePresenter(this);
        }

        private void ConfirmCloseFinancialBalanceForm_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            presenter.OnCancel();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            presenter.OnOk();
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

        public void SetEntryMinimumDate(DateTime dateTime)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DateTime>(SetEntryMinimumDate), dateTime);
                return;
            }
            entryDateTimePicker.MinDate = dateTime;
        }

        public void SetEntryMaximumDate(DateTime dateTime)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DateTime>(SetEntryMaximumDate), dateTime);
                return;
            }
            entryDateTimePicker.MaxDate = dateTime;
        }

        public void SetEntryDateEnabled(bool enabled)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetEntryDateEnabled), enabled);
                return;
            }
            entryDateTimePicker.Enabled = false;
        }

        public void SetOkButtonEnabled(bool enabled)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetOkButtonEnabled), enabled);
                return;
            }
            okButton.Enabled = enabled;
        }

        public void SetWarningMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetWarningMessage), message);
                return;
            }
            messageLabel.Text = message;
            messageLabel.Visible = true;
        }

        public bool ShowBinaryQuestion(string message)
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<string, bool>(ShowBinaryQuestion), message);
            }
            return MessageBox.Show(message, "TAD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public DateTime GetEntryDate()
        {
            if (InvokeRequired)
            {
                return (DateTime)Invoke(new Func<DateTime>(GetEntryDate));
            }
            return entryDateTimePicker.Value;
        }
    }
}
