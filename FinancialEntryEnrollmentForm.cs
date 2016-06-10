using System;
using System.Windows.Forms;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class FinancialEntryEnrollmentForm : Form, IFinancialEntryEnrollmentView
    {
        private readonly IFinancialEntryEnrollmentPresenter presenter;
        private readonly FinancialEntryViewItem currentViewItem;

        public FinancialEntryEnrollmentForm()
        {
            InitializeComponent();
            presenter = new FinancialEntryEnrollmentPresenter(this);
        }

        public FinancialEntryEnrollmentForm(FinancialEntryViewItem viewItem)
            : this()
        {
            currentViewItem = viewItem;
        }

        private void FinancialEntryEnrollmentForm_Load(object sender, EventArgs e)
        {
            if (currentViewItem == null)
            {
                presenter.InitView();
            }
            else
            {
                presenter.InitViewWith(currentViewItem);
            }
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

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void targetRadionButtonGroupPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
