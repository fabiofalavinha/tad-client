using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;

namespace TadManagementTool
{
    public partial class FinancialReferenceListUserControl : UserControl, IFinancialReferenceListView
    {
        private readonly IMainView parentView;
        private readonly IFinancialReferenceListPresenter presenter;

        public FinancialReferenceListUserControl(IMainView parentView)
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            this.parentView = parentView;
            this.presenter = new FinancialReferenceListPresenter(this);
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

        private void newFinancialReferenceButton_Click(object sender, EventArgs e)
        {
            presenter.OpenFinancialReferenceEnrollmentView();
        }

        private void FinancialReferenceListUserControl_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        public void SetCollaboratorList(IList<FinancialReferenceViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialReferenceViewItem>>(SetCollaboratorList), list);
                return;
            }
            bindingSource.DataSource = list;
            dataGridView.DataSource = bindingSource;
            bindingSource.ResetBindings(false);
            dataGridView.ClearSelection();
            dataGridView.AutoResizeColumns();
        }

        public void OpenFinancialReferenceEnrollmentView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenFinancialReferenceEnrollmentView));
                return;
            }
            parentView.ShowControlView(new FinancialReferenceUserControl(parentView)
            {
                Dock = DockStyle.Fill
            });
        }
    }
}
