using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TadManagementTool.View.Impl;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class FinancialReferenceUserControl : UserControl, IFinancialReferenceView
    {
        private readonly IMainView parentView;
        private readonly IFinancialReferencePresenter presenter;

        public FinancialReferenceUserControl(IMainView parentView)
        {
            InitializeComponent();
            this.parentView = parentView;
            this.presenter = new FinancialReferencePresenter(this);
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

        private void FinancialReferenceUserControl_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        private void backToListButton_Click(object sender, EventArgs e)
        {
            presenter.OpenFinancialReferenceListView();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            presenter.OnSave();
        }

        public void SetCategoryList(IList<CategoryViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<CategoryViewItem>>(SetCategoryList), list);
                return;
            }
            categoryComboBox.Items.Clear();
            categoryComboBox.Items.AddRange(list.ToArray());
        }

        public void OpenFinancialReferenceListView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenFinancialReferenceListView));
                return;
            }
            parentView.ShowControlView(new FinancialReferenceListUserControl(parentView)
            {
                Dock = DockStyle.Fill
            });
        }
    }
}
