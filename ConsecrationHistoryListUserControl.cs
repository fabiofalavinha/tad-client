using System;
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
    public partial class ConsecrationHistoryListUserControl : UserControl, IConsecrationHistoryListView
    {
        
        public ConsecrationHistoryListUserControl()
        {
            InitializeComponent();            
        }

        public void CloseView()
        {
            throw new NotImplementedException();
        }

        public void HideWaitingPanel()
        {
            throw new NotImplementedException();
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowWaitingPanel(string message = null)
        {
            throw new NotImplementedException();
        }

        public void ShowWarningMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
