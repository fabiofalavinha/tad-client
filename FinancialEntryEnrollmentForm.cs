using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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

        private bool populateFormFields = false;

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
            DialogResult = DialogResult.OK;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            presenter.OnSaveFinancialEntry();
        }

        private void targetTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            presenter.OnCollaboratorTypeSelection();
        }

        private void entryValueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!populateFormFields)
            {
                presenter.OnEntryValueChanged();
            }
        }

        private void financialTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.OnFinancialReferenceSelected();
        }

        public bool IsCollaboratorTypeSelected()
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<bool>(IsCollaboratorTypeSelected));
            }
            return targetCollaboratorTypeRadioButton.Checked;
        }

        public bool IsNonCollaboratorTypeSelected()
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<bool>(IsNonCollaboratorTypeSelected));
            }
            return targetNonCollaboratorTypeRadioButton.Checked;
        }

        public void SetCollaboratorList(IList<FinancialTargetViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialTargetViewItem>>(SetCollaboratorList), list);
                return;
            }
            targetComboBox.DisplayMember = "Name";
            targetComboBox.ValueMember = "Id";
            targetComboBox.Enabled = true;
            targetComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            targetComboBox.Items.Clear();
            targetComboBox.Items.AddRange(list.ToArray());
        }

        public void SetOtherCollaboratorList(IList<FinancialTargetViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialTargetViewItem>>(SetOtherCollaboratorList), list);
                return;
            }
            targetComboBox.DisplayMember = "Name";
            targetComboBox.ValueMember = "Id";
            targetComboBox.Enabled = true;
            targetComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            targetComboBox.Items.Clear();
            targetComboBox.Items.AddRange(list.ToArray());
        }

        public void SetFinancialEntry(FinancialEntryViewItem viewItem)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<FinancialEntryViewItem>(SetFinancialEntry), viewItem);
                return;
            }
            populateFormFields = true;
            try
            {
                entryDateTimePicker.Value = viewItem.Wrapper.ToEntryDate();
                targetCollaboratorTypeRadioButton.Checked = viewItem.Wrapper.Target.ToTargetType() == FinancialTargetType.Colaborator;
                targetNonCollaboratorTypeRadioButton.Checked = viewItem.Wrapper.Target.ToTargetType() == FinancialTargetType.NonColaborator;
                targetOtherCollaboratorTypeRadioButton.Checked = viewItem.Wrapper.Target.ToTargetType() == FinancialTargetType.Other;
                targetComboBox.SelectedItem = targetComboBox.Items.Cast<FinancialTargetViewItem>().SingleOrDefault(i => i.Id.Equals(viewItem.TargetReference));
                financialTypeComboBox.SelectedItem = financialTypeComboBox.Items.Cast<FinancialReferenceViewItem>().SingleOrDefault(r => r.Id.Equals(viewItem.Wrapper.Type.Id));
                additionalTextTextBox.Text = viewItem.Wrapper.AdditionalText;
                categoryTypeLabel.Text = viewItem.Wrapper.Type.Category == (int)Category.Payable ? "-" : "+";
                // currentBalanceValueLabel.Text = viewItem.Wrapper.Balance.Value.ToString(new CultureInfo("en-US"));
                if (viewItem.Wrapper.Value > 0)
                {
                    entryValueTextBox.Text = viewItem.Wrapper.Value.ToString("#0.00#", new CultureInfo("en-US"));
                }
                var visible = string.IsNullOrWhiteSpace(viewItem.Id);
                balancePreviewValueLabel.Visible = visible;
                balanceSeparatorPanel.Visible = visible;
                balancePreviewLabel.Visible = visible;
                balancePreviewValueLabel.Text = viewItem.Wrapper.PreviewBalance.Value.ToString(new CultureInfo("en-US"));
            }
            finally
            {
                populateFormFields = false;
            }
        }

        public void SetFinancialEntryDataEnabled(bool enabled)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetFinancialEntryDataEnabled), enabled);
                return;
            }
            entryDateTimePicker.Enabled = false;
            targetCollaboratorTypeRadioButton.Enabled = enabled;
            targetOtherCollaboratorTypeRadioButton.Enabled = enabled;
            targetComboBox.Enabled = enabled;
            financialTypeComboBox.Enabled = enabled;
            additionalTextTextBox.Enabled = enabled;
            entryValueTextBox.Enabled = enabled;
            saveButton.Enabled = enabled;
        }

        public void SetFinancialReferenceList(IList<FinancialReferenceViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialReferenceViewItem>>(SetFinancialReferenceList), list);
                return;
            }
            financialTypeComboBox.Enabled = true;
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

        public string GetFinancialEntryValue()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetFinancialEntryValue));
            }
            return entryValueTextBox.Text;
        }

        public void SetEntryPreviewValue(string previewValue)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetEntryPreviewValue), previewValue);
                return;
            }
            balancePreviewValueLabel.Text = previewValue;
        }

        public string GetEntryPreviewValue()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetEntryPreviewValue));
            }
            return balancePreviewValueLabel.Text;
        }

        public void SetEntryValue(decimal value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<decimal>(SetEntryValue), value);
                return;
            }
            entryValueTextBox.Text = value.ToString();
        }

        public void SetEntryPreviewValueColor(Color color)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Color>(SetEntryPreviewValueColor), color);
                return;
            }
            balancePreviewValueLabel.ForeColor = color;
        }

        public string GetAdditionalText()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetAdditionalText));
            }
            return additionalTextTextBox.Text;
        }

        public string GetEntryDateAsString(string formatter)
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string, string>(GetEntryDateAsString), formatter);
            }
            return entryDateTimePicker.Value.ToString(formatter);
        }

        public FinancialTargetType? GetEntryTargetType()
        {
            if (InvokeRequired)
            {
                return (FinancialTargetType?)Invoke(new Func<FinancialTargetType?>(GetEntryTargetType));
            }
            if (targetCollaboratorTypeRadioButton.Checked)
            {
                return FinancialTargetType.Colaborator;
            }
            else if (targetNonCollaboratorTypeRadioButton.Checked)
            {
                return FinancialTargetType.NonColaborator;
            }
            else if (targetOtherCollaboratorTypeRadioButton.Checked)
            {
                return FinancialTargetType.Other;
            }
            return null;
        }

        public FinancialTargetViewItem GetEntryTarget()
        {
            if (InvokeRequired)
            {
                return (FinancialTargetViewItem)Invoke(new Func<FinancialTargetViewItem>(GetEntryTarget));
            }
            var selected = (FinancialTargetViewItem)targetComboBox.SelectedItem;
            if (selected == null)
            {
                var inputText = targetComboBox.Text;
                if (!string.IsNullOrWhiteSpace(inputText))
                {
                    return new FinancialTargetViewItem()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = inputText
                    };
                }
            }
            return selected;
        }

        public FinancialReferenceViewItem GetEntryReference()
        {
            if (InvokeRequired)
            {
                return (FinancialReferenceViewItem)Invoke(new Func<FinancialReferenceViewItem>(GetEntryReference));
            }
            return (FinancialReferenceViewItem)financialTypeComboBox.SelectedItem;
        }

        public void SetCategoryType(Category category)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Category>(SetCategoryType), category);
                return;
            }
            if (category == Category.Payable)
            {
                categoryTypeLabel.Text = "-";
            }
            else if (category == Category.Receivable)
            {
                categoryTypeLabel.Text = "+";
            }
        }

        public void SetEntryDateOptionEnabled(bool enabled)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetEntryDateOptionEnabled), enabled);
                return;
            }
            entryDateTimePicker.Enabled = enabled;
        }

        public void SetNonCollaboratorList(IList<FinancialTargetViewItem> viewItems)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialTargetViewItem>>(SetNonCollaboratorList), viewItems);
                return;
            }
            targetComboBox.DisplayMember = "Name";
            targetComboBox.ValueMember = "Id";
            targetComboBox.Enabled = true;
            targetComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            targetComboBox.Items.Clear();
            targetComboBox.Items.AddRange(viewItems.ToArray());
        }

        public void SetFinancialEntryMinimumDate(DateTime dateTime)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DateTime>(SetFinancialEntryMinimumDate), dateTime);
                return;
            }
            entryDateTimePicker.MinDate = dateTime;
        }
    }
}
