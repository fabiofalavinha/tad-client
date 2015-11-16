using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TadManagementTool.Model.Financial;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class FinancialReferenceUserControl : UserControl, IFinancialReferenceView
    {
        private readonly IMainView parentView;
        private readonly IFinancialReferencePresenter presenter;

        public FinancialReferenceUserControl(IMainView parentView, FinancialReferenceViewItem viewItem)
        {
            InitializeComponent();
            this.parentView = parentView;
            presenter = new FinancialReferencePresenter(this, viewItem != null ? viewItem.Wrapper : null);
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

        public void SetDescription(string description)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetDescription), description);
                return;
            }
            descriptionTextBox.Text = description;
        }

        public void SetCategory(Category category)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Category>(SetCategory), category);
                return;
            }
            var found = categoryComboBox.Items.Cast<CategoryViewItem>().SingleOrDefault(c => c.Wrapper == category);
            if (found != null) 
            {
                categoryComboBox.SelectedItem = found;
            }
        }

        public void SetAssociatedWithCollaboratorChecked(bool value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetAssociatedWithCollaboratorChecked), value);
                return;
            }
            associatedWithCollaboratorCheckBox.Checked = value;
        }

        public string GetDescription()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetDescription));
            }
            return descriptionTextBox.Text;
        }

        public bool GetAssociatedWithCollaboratorChecked()
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<bool>(GetAssociatedWithCollaboratorChecked));
            }
            return associatedWithCollaboratorCheckBox.Checked;
        }

        public CategoryViewItem GetCategorySelected()
        {
            if (InvokeRequired)
            {
                return (CategoryViewItem)Invoke(new Func<CategoryViewItem>(GetCategorySelected));
            }
            return (CategoryViewItem)categoryComboBox.SelectedItem;
        }
    }
}
