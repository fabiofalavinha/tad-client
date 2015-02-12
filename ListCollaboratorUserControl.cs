﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TadManagementTool.View;
using TadManagementTool.View.Impl;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.Model;

namespace TadManagementTool
{
    public partial class ListCollaboratorUserControl : UserControl, IListCollaboratorView
    {
        private readonly IMainView parentView;
        private readonly IListCollaboratorPresenter presenter;

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

        public void SetCollaboratorList(IList<Collaborator> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<Collaborator>>(SetCollaboratorList), list);
                return;
            }
            bindingSource.DataSource = list;
            dataGridView.DataSource = bindingSource;
            bindingSource.ResetBindings(false);
            dataGridView.ClearSelection();
            dataGridView.AutoResizeColumns();
        }

        public Collaborator GetCollaboratorSelected()
        {
            if (InvokeRequired)
            {
                return (Collaborator)Invoke(new Func<Collaborator>(GetCollaboratorSelected));
            }
            if (dataGridView.SelectedRows.Count > 0)
            {
                return (Collaborator)dataGridView.SelectedRows[0].DataBoundItem;
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

        public void OpenCollaboratorView(Collaborator collaborator)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Collaborator>(OpenCollaboratorView), collaborator);
                return;
            }
            parentView.ShowControlView(new CollaboratorView(parentView, collaborator)
            {
                Dock = DockStyle.Fill
            });
        }
    }
}