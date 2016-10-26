using System;
using System.Windows.Forms;
using TadManagementTool.View.Impl;

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
