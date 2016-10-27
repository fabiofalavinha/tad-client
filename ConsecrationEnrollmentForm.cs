using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;

namespace TadManagementTool
{
    public partial class ConsecrationEnrollmentForm : Form, IConsecrationEnrollmentView
    {
        public IConsecrationEnrollmentPresenter presenter;

        public ConsecrationEnrollmentForm(string eventId)
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            presenter = new ConsecrationEnrollmentPresenter(this, eventId);
        }

        public void CloseView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(CloseView));
                return;
            }
            DialogResult = DialogResult.OK;
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

        public void SetDialogResult(DialogResult dialogResult)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DialogResult>(SetDialogResult), dialogResult);
                return;
            }
            DialogResult = dialogResult;
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

        public void ShowWarningMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowWarningMessage), message);
                return;
            }
            MessageBox.Show(message, "TAD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            presenter.OnSaveConsecration();
        }

        private void ConsecrationEnrollmentForm_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        public void SetElementList(IList<Element> elements)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<Element>>(SetElementList), elements);
                return;
            }
            bindingSource.DataSource = elements;
            dataGridView.DataSource = bindingSource;
            bindingSource.ResetBindings(false);
            dataGridView.ClearSelection();
            dataGridView.AutoResizeColumns();
        }

        public void SetComunicationMessage(CommunicationMessage message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<CommunicationMessage>(SetComunicationMessage), message);
                return;
            }
            mailContentTextBox.Text = message.Content;
        }
    }
}
