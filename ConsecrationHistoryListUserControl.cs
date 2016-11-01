using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Presenter;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class ConsecrationHistoryListUserControl : UserControl, IConsecrationHistoryListView
    {
        private readonly IMainView parentView;
        private readonly IConsecrationHistoryListPresenter presenter;

        public ConsecrationHistoryListUserControl(IMainView parentView)
        {
            InitializeComponent();
            presenter = new ConsecrationHistoryListPresenter(this);
        }

        public ConsecrationViewItem GetConsecrationSelected()
        {
            if (InvokeRequired)
            {
                return (ConsecrationViewItem)Invoke(new Func<ConsecrationViewItem>(GetConsecrationSelected));
            }
            var selectedRow = consecrationDataGridView.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            if (selectedRow != null)
            {
                return (ConsecrationViewItem)selectedRow.DataBoundItem;
            }
            return null;
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

        public DialogResult OpenConsecrationHistoryDetails(IConsecrationInitializationStrategy strategy)
        {
            if (InvokeRequired)
            {
                return (DialogResult)Invoke(new Func<IConsecrationInitializationStrategy, DialogResult>(OpenConsecrationHistoryDetails), strategy);
            }
            using (var form = new ConsecrationEnrollmentForm(strategy))
            {
                return form.ShowDialog();
            }
        }

        public void SetConsecrationList(IList<ConsecrationViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<ConsecrationViewItem>>(SetConsecrationList), list);
                return;
            }
            bindingSource.DataSource = list;
            consecrationDataGridView.DataSource = bindingSource;
            bindingSource.ResetBindings(false);
            consecrationDataGridView.ClearSelection();
            consecrationDataGridView.AutoResizeColumns();
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

        private void consecrationDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            presenter.OnSelectConsecrationHistoryView();
        }

    }
}
