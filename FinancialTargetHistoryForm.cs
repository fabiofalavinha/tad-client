using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TadManagementTool.Model.Financial;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class FinancialTargetHistoryForm : Form, IFinancialTargetHistoryView
    {
        private readonly IFinancialTargetHistoryPresenter presenter;

        public FinancialTargetHistoryForm(FinancialTargetHistoryFilter filter)
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            presenter = new FinancialTargetHistoryPresenter(this, filter);
        }

        private void FinancialTargetHistoryForm_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        public void CloseView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(HideWaitingPanel));
                return;
            }
            Close();
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

        public void SetDialogResult(DialogResult result)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DialogResult>(SetDialogResult), result);
                return;
            }
            DialogResult = result;
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

        public void SetFinancialHistoryFilterDateFrom(DateTime date)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DateTime>(SetFinancialHistoryFilterDateFrom), date);
                return;
            }
            fromDateTimePicker.Value = date;
        }

        public void SetFinancialHistoryFilterDateTo(DateTime date)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DateTime>(SetFinancialHistoryFilterDateTo), date);
                return;
            }
            toDateTimePicker.Value = date;
        }

        public void SetFinancialHistoryList(IList<FinancialEntryViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialEntryViewItem>>(SetFinancialHistoryList), list);
                return;
            }
            bindingSource.DataSource = list;
            dataGridView.DataSource = bindingSource;
            bindingSource.ResetBindings(false);
            dataGridView.ClearSelection();
            dataGridView.AutoResizeColumns();
        }

        public void SetReferenceTypeList(IList<FinancialReferenceOptionViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialReferenceOptionViewItem>>(SetReferenceTypeList), list);
                return;
            }
            referenceTypeComboBox.Items.Clear();
            referenceTypeComboBox.Items.AddRange(list.ToArray());
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            presenter.OnSearchFinancialHistoryList();
        }

        public DateTime GetFinancialHistoryDateFrom()
        {
            if (InvokeRequired)
            {
                return (DateTime)Invoke(new Func<DateTime>(GetFinancialHistoryDateFrom));
            }
            return fromDateTimePicker.Value;
        }

        public DateTime GetFinancialHistoryDateTo()
        {
            if (InvokeRequired)
            {
                return (DateTime)Invoke(new Func<DateTime>(GetFinancialHistoryDateTo));
            }
            return toDateTimePicker.Value;
        }

        public FinancialReferenceOptionViewItem GetFinancialReferenceTypeSelected()
        {
            if (InvokeRequired)
            {
                return (FinancialReferenceOptionViewItem)Invoke(new Func<FinancialReferenceOptionViewItem>(GetFinancialReferenceTypeSelected));
            }
            return (FinancialReferenceOptionViewItem)referenceTypeComboBox.SelectedItem;
        }

        public void SetReferenceTypeSelected(FinancialReferenceOptionViewItem viewItem)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<FinancialReferenceOptionViewItem>(SetReferenceTypeSelected), viewItem);
                return;
            }
            referenceTypeComboBox.SelectedItem = viewItem;
        }

        public void SetTitle(string title)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetTitle), title);
                return;
            }
            Text = $"{title} - Histórico de Lançamentos...";
        }
    }
}
