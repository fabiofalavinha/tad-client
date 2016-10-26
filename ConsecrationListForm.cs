﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TadManagementTool.View.Impl;

namespace TadManagementTool
{
    public partial class ConsecrationListForm : Form, IConsecrationHistoryListView
    {
        public ConsecrationListForm()
        {
            InitializeComponent();
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
    }
}
