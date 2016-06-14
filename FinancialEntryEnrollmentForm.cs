using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TadManagementTool.Model.Financial;
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
            presenter.OnSaveFinancialEntry();
        }

        private void targetCollaboratorTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            presenter.OnCollaboratorTypeSelection();
        }

        private void targetNonCollaboratorTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            presenter.OnCollaboratorTypeSelection();
        }

        public bool IsCollaboratorTypeSelected()
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<bool>(IsCollaboratorTypeSelected));
            }
            return targetCollaboratorTypeRadioButton.Checked;
        }

        public void SetCollaboratorList(IList<FinancialTargetViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialTargetViewItem>>(SetCollaboratorList), list);
                return;
            }
            targetComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            targetComboBox.Items.Clear();
            targetComboBox.Items.AddRange(list.ToArray());
        }

        public void SetNonCollaboratorList(IList<FinancialTargetViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialTargetViewItem>>(SetNonCollaboratorList), list);
                return;
            }
            targetComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            targetComboBox.Items.Clear();
            targetComboBox.Items.AddRange(list.ToArray());
            var toolTip = new ToolTip()
            {
                IsBalloon = true,
                ToolTipIcon = ToolTipIcon.Info,
                ToolTipTitle = "Selecione a origem do lançamento financeiro"
            };
            toolTip.Show(string.Empty, targetComboBox, 0);
            toolTip.Show("Caso você não encontre o valor desejado, digite um novo valor no campo", targetComboBox);
        }

        public void SetFinancialEntry(FinancialEntryViewItem viewItem)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<FinancialEntryViewItem>(SetFinancialEntry), viewItem);
                return;
            }
            entryDateTimePicker.Value = viewItem.Wrapper.Date;
            targetCollaboratorTypeRadioButton.Checked = viewItem.Wrapper.Target.Type == FinancialTargetType.Colaborator;
            targetNonCollaboratorTypeRadioButton.Checked = viewItem.Wrapper.Target.Type == FinancialTargetType.NonColaborator;
            targetComboBox.SelectedItem = targetComboBox.Items.Cast<FinancialTargetViewItem>().SingleOrDefault(i => i.Id.Equals(viewItem.TargetReference));
            financialTypeComboBox.SelectedItem = financialTypeComboBox.Items.Cast<FinancialReferenceViewItem>().SingleOrDefault(r => r.Id.Equals(viewItem.Wrapper.Type.Id));
            additionalTextTextBox.Text = viewItem.Wrapper.AdditionalText;
            categoryPayableRadionButton.Checked = viewItem.Wrapper.Type.Category == (int)Category.Payable;
            categoryReceivableRadionButton.Checked = viewItem.Wrapper.Type.Category == (int)Category.Receivable;
            currentBalanceValueLabel.Text = viewItem.Wrapper.Balance.Value.ToString();
            entryValueTextBox.Text = viewItem.Wrapper.Value.ToString();
            balancePreviewValueLabel.Text = viewItem.Wrapper.PreviewBalance.ToString();
        }

        public void SetFinancialReferenceList(IList<FinancialReferenceViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialReferenceViewItem>>(SetFinancialReferenceList), list);
                return;
            }
            financialTypeComboBox.Items.Clear();
            financialTypeComboBox.Items.AddRange(list.ToArray());
        }

        public void SetCurrentBalance(string value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetCurrentBalance), value);
                return;
            }
            currentBalanceValueLabel.Text = value;
        }
    }
}
