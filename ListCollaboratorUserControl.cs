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

namespace TadManagementTool
{
    public partial class ListCollaboratorUserControl : UserControl, IListCollaboratorView
    {
        private readonly IListCollaboratorPresenter presenter;

        public ListCollaboratorUserControl()
        {
            InitializeComponent();
            presenter = new ListCollaboratorPresenter(this);
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
    }
}
