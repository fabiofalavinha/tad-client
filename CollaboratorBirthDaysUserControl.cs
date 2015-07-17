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
using TadManagementTool.Model;

namespace TadManagementTool
{
    public partial class CollaboratorBirthDaysUserControl : UserControl, ICollaboratorBirthDaysView
    {
        private readonly ICollaboratorBirthDaysPresenter presenter;

        public CollaboratorBirthDaysUserControl()
        {
            InitializeComponent();
            this.presenter = new CollaboratorBirthDaysPresenter(this);
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

        private void CollaboratorBirthDaysUserControl_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        public void SetBirthdayList(IList<BirthdayList> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<BirthdayList>>(SetBirthdayList), list);
                return;
            }
            flowLayoutPanel.Controls.Clear();
            flowLayoutPanel.Controls.AddRange(list.Select(i => new CollaboratorBirthDayItemUserControl(i)).ToArray());
        }

        private void flowLayoutPanel_MouseEnter(object sender, EventArgs e)
        {
            flowLayoutPanel.Focus();
        }
    }
}
