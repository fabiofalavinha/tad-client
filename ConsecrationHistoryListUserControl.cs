using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class ConsecrationHistoryListUserControl : UserControl, IConsecrationHistoryListView
    {
        private readonly IMainView parentView;

        public ConsecrationHistoryListUserControl(IMainView parentView)
        {
            InitializeComponent();
            this.parentView = parentView;
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
    }
}
