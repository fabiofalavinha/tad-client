﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class ListCollaboratorUserControl : UserControl, IListCollaboratorView
    {
        private readonly IMainView parentView;
        private readonly IListCollaboratorPresenter presenter;
        private readonly Dictionary<string, SortOrder> columnSortOrderMap = new Dictionary<string, SortOrder>();

        private bool updateColumnOrderDisplayIndex = false;

        public ListCollaboratorUserControl(IMainView parentView)
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            this.parentView = parentView;
            this.presenter = new ListCollaboratorPresenter(this);
        }

        private void ListCollaboratorUserControl_Load(object sender, EventArgs e)
        {
            presenter.InitView();
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

        private void removeCollaboratorButton_Click(object sender, EventArgs e)
        {
            presenter.OnRemoveCollaborator();
        }

        private void newCollaboratorButton_Click(object sender, EventArgs e)
        {
            presenter.OnNewCollaborator();
        }

        private void collaboratorDetailButton_Click(object sender, EventArgs e)
        {
            presenter.OnViewCollaboratorDetails();
        }

        private void BeginUpdateColumnOrderDisplayIndex()
        {
            updateColumnOrderDisplayIndex = true;
        }

        private void EndUpdateColumnOrderDisplayIndex()
        {
            updateColumnOrderDisplayIndex = false;
        }

        public void SetCollaboratorList(IList<View.Items.CollaboratorViewItem> list, CollaboratorPreferences collaboratorPreferences)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<View.Items.CollaboratorViewItem>, CollaboratorPreferences>(SetCollaboratorList), list, collaboratorPreferences);
                return;
            }
            bindingSource.DataSource = list;
            dataGridView.DataSource = bindingSource;
            bindingSource.ResetBindings(false);
            dataGridView.ClearSelection();
            dataGridView.AutoResizeColumns();
            BeginUpdateColumnOrderDisplayIndex();
            foreach (var column in dataGridView.Columns.Cast<DataGridViewColumn>())
            {
                var tableColumn = collaboratorPreferences.GetColumn(column.Name);
                column.DisplayIndex = tableColumn.Index;
            }
            EndUpdateColumnOrderDisplayIndex();
        }

        public CollaboratorViewItem GetCollaboratorSelected()
        {
            if (InvokeRequired)
            {
                return (View.Items.CollaboratorViewItem)Invoke(new Func<View.Items.CollaboratorViewItem>(this.GetCollaboratorSelected));
            }
            if (dataGridView.SelectedRows.Count > 0)
            {
                return (View.Items.CollaboratorViewItem)dataGridView.SelectedRows[0].DataBoundItem;
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

        public void OpenCollaboratorView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenCollaboratorView));
                return;
            }
            parentView.ShowControlView(new CollaboratorView(parentView)
            {
                Dock = DockStyle.Fill
            });
        }

        public void OpenCollaboratorView(Model.Collaborator collaborator)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Model.Collaborator>(OpenCollaboratorView), collaborator);
                return;
            }
            parentView.ShowControlView(new CollaboratorView(parentView, collaborator)
            {
                Dock = DockStyle.Fill
            });
        }

        public void SetActiveCollaboratorCount(int count)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<int>(SetActiveCollaboratorCount), count);
                return;
            }
            activeCollaboratorCountValueLabel.Text = count.ToString();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            presenter.OnViewCollaboratorDetails();
        }

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            presenter.OnExportToExcel();
        }

        public IList<View.Items.CollaboratorViewItem> GetCollaboratorList()
        {
            if (InvokeRequired)
            {
                return (IList<View.Items.CollaboratorViewItem>)Invoke(new Func<IList<View.Items.CollaboratorViewItem>>(GetCollaboratorList));
            }
            return dataGridView.Rows.Cast<DataGridViewRow>().Select(r => (CollaboratorViewItem)r.DataBoundItem).ToArray();
        }

        public string SelectFilePathToSaveExcelFile()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(SelectFilePathToSaveExcelFile));
            }
            var dialogResult = exportToExcelSaveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                return exportToExcelSaveFileDialog.FileName;
            }
            return null;
        }

        public void ShowSuccessMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowSuccessMessage), message);
                return;
            }
            MessageBox.Show(message, "TAD", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var column = dataGridView.Columns[e.ColumnIndex];
            SortOrder sortOrder;
            if (columnSortOrderMap.TryGetValue(column.DataPropertyName, out sortOrder))
            {
                columnSortOrderMap.Remove(column.DataPropertyName);
                sortOrder =
                    sortOrder == SortOrder.Ascending
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
            }
            else
            {
                sortOrder = SortOrder.Ascending;
            }
            columnSortOrderMap.Add(column.DataPropertyName, sortOrder);
            presenter.OnSortCollaboratorList(column.DataPropertyName, sortOrder);
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var row = dataGridView.Rows[e.RowIndex];
            var viewItem = (View.Items.CollaboratorViewItem)row.DataBoundItem;
            if (viewItem.Wrapper.UserRole == UserRole.NonCollaborator)
            {
                e.CellStyle.BackColor = Color.Yellow;
            }
            else
            {
                e.CellStyle.BackColor = viewItem.Wrapper.Active ? Color.LightGreen : Color.Coral;
            }
        }

        public bool IsActiveFilterChecked()
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<bool>(IsActiveFilterChecked));
            }
            return filterActiveCheckBox.Checked;
        }

        private void collaboratorSearchButton_Click(object sender, EventArgs e)
        {
            presenter.OnSearchCollaborators();
        }

        private void dataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!updateColumnOrderDisplayIndex)
            {
                presenter.OnColumnReOrder(e.Column.Name, e.Column.DisplayIndex);
            }
        }

        public bool IsNonCollaboratorFilterChecked()
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<bool>(IsNonCollaboratorFilterChecked));
            }
            return nonCollaboratorFilterCheckBox.Checked;
        }
    }
}
