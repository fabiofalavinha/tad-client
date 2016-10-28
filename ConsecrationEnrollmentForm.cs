using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class ConsecrationEnrollmentForm : Form, IConsecrationEnrollmentView
    {
        public readonly IConsecrationEnrollmentPresenter presenter;

        private IList<CollaboratorViewItem> currentCollaborators;
        private IList<ElementUnitViewItem> currentElementUnits;

        public ConsecrationEnrollmentForm(Event currentEvent)
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            dataGridView.CellValidating += DataGridView_CellValidating;
            presenter = new ConsecrationEnrollmentPresenter(this, currentEvent);
        }

        private void DataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
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

        public void HideWaitingPanel()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(HideWaitingPanel));
                return;
            }
            modalWaitingPanel.Hide();
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            presenter.OnSaveConsecration();
        }

        private void ConsecrationEnrollmentForm_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        public void SetElementList(IList<Element> elements)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<Element>>(SetElementList), elements);
                return;
            }
            bindingSource.DataSource = elements;
            dataGridView.DataSource = bindingSource;
            bindingSource.ResetBindings(false);
            dataGridView.ClearSelection();
            dataGridView.AutoResizeColumns();
        }

        public void SetComunicationMessage(CommunicationMessage message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<CommunicationMessage>(SetComunicationMessage), message);
                return;
            }
            mailContentTextBox.Text = message.Content;
        }

        public void SetCollaboratorList(IList<CollaboratorViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<CollaboratorViewItem>>(SetCollaboratorList), list);
                return;
            }
            currentCollaborators = list;
        }

        public void SetElementUnitList(IList<ElementUnitViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<ElementUnitViewItem>>(SetElementUnitList), list);
                return;
            }
            currentElementUnits = list;
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            grid.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c =>
            {
                if (c.Name.Equals("ElementUnitColumn"))
                {
                    var comboBox = c as DataGridViewComboBoxColumn;
                    if (comboBox != null)
                    {
                        comboBox.ValueMember = "Id";
                        comboBox.DisplayMember = "Name";
                        comboBox.Items.Clear();
                        comboBox.Items.AddRange(currentElementUnits.Select(u => u.Name).ToArray());
                    }
                }
                else if (c.Name.Equals("PrimaryCollaboratorColumn") || c.Name.Equals("SecondaryCollaboratorColumn"))
                {
                    var comboBox = c as DataGridViewComboBoxColumn;
                    if (comboBox != null)
                    {
                        comboBox.ValueMember = "Id";
                        comboBox.DisplayMember = "Name";
                        comboBox.Items.Clear();
                        comboBox.Items.AddRange(currentCollaborators.Select(cc => cc.Name).ToArray());
                    }
                }
            });
        }
    }
}
