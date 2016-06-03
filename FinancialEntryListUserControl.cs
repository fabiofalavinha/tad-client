using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class FinancialEntryListUserControl : BaseUserControl, IFinancialEntryListView
    {
        private readonly IMainView parentView;
        private readonly IFinancialEntryListPresenter presenter;

        private FinancialReferenceViewItem[] currentFinancialReferenceViewItems;

        public FinancialEntryListUserControl(IMainView parentView)
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            this.parentView = parentView;
            presenter = new FinancialEntryListPresenter(this);
            currentFinancialReferenceViewItems = new FinancialReferenceViewItem[] { };
        }

        private void FinancialEntryListUserControl_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Console.WriteLine("Row added");
            var gridView = (DataGridView)sender;
            var row = gridView.Rows[e.RowIndex];
            var financialEntryTargetColumn = row.Cells["financialEntryTargetColumn"] as DataGridViewComboBoxCell;
            financialEntryTargetColumn.DataSource = currentFinancialReferenceViewItems;
            financialEntryTargetColumn.DisplayMember = "Description";
            financialEntryTargetColumn.ValueMember = "Id";
            presenter.OnNewFinancialEntryAdded();
        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            Console.WriteLine("Users row added");
            var gridView = (DataGridView)sender;
            var dataBoundItem = e.Row.DataBoundItem;
            Console.WriteLine(dataBoundItem);
            presenter.OnNewFinancialEntryAdded();
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Console.WriteLine($"DataBindingComplete {e.ListChangedType}");
        }

        private void dataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            Console.WriteLine("Row validating");
        }

        private void dataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            Console.WriteLine("Users deleted row");
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Console.WriteLine("Users deleting row");
        }

        private void dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("Row validated");
        }

        public void SetFinancialReferenceList(IList<FinancialReferenceViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialReferenceViewItem>>(SetFinancialReferenceList), list);
                return;
            }
            currentFinancialReferenceViewItems = list.ToArray();
        }

        private void dataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.CellType.Name == "financialReferenceTypeColumn")
            {
                Console.WriteLine("financialReferenceTypeColumn added");
            }
        }
    }
}
