using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class FinancialReferenceListUserControl : BaseUserControl, IFinancialReferenceListView
    {
        private readonly IMainView parentView;
        private readonly IFinancialReferenceListPresenter presenter;

        public FinancialReferenceListUserControl(IMainView parentView)
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            this.parentView = parentView;
            presenter = new FinancialReferenceListPresenter(this);
        }

        private void newFinancialReferenceButton_Click(object sender, EventArgs e)
        {
            presenter.OpenFinancialReferenceEnrollmentView();
        }

        private void FinancialReferenceListUserControl_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        public void OpenFinancialReferenceEnrollmentView(FinancialReferenceViewItem selected)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<FinancialReferenceViewItem>(OpenFinancialReferenceEnrollmentView), selected);
                return;
            }
            parentView.ShowControlView(new FinancialReferenceUserControl(parentView, selected)
            {
                Dock = DockStyle.Fill
            });
        }

        public void SetFinancialReferenceList(IList<FinancialReferenceViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialReferenceViewItem>>(SetFinancialReferenceList), list);
                return;
            }
            bindingSource.DataSource = list;
            dataGridView.DataSource = bindingSource;
            bindingSource.ResetBindings(false);
            dataGridView.ClearSelection();
            dataGridView.AutoResizeColumns();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            presenter.OnRemove();
        }

        public FinancialReferenceViewItem GetFinancialReferenceSelected()
        {
            if (InvokeRequired)
            {
                return (FinancialReferenceViewItem)Invoke(new Func<FinancialReferenceViewItem>(GetFinancialReferenceSelected));
            }
            var row = dataGridView.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            if (row != null)
            {
                return (FinancialReferenceViewItem)row.DataBoundItem;
            }
            return null;
        }

        public bool ShowBinaryQuestion(string message)
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<string, bool>(ShowBinaryQuestion), message);
            }
            return MessageBox.Show(message, "TAD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            presenter.OpenFinancialReferenceEnrollmentView();
        }
    }
}
