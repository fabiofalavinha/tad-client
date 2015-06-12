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
    public partial class CalendarUserControl : UserControl, ICalendarView
    {
        private readonly IMainView parentView;
        private readonly ICalendarPresenter presenter;

        public CalendarUserControl(IMainView parentView)
        {
            InitializeComponent();
            this.parentView = parentView;
            this.presenter = new CalendarPresenter(this);
        }

        private void CalendarUserControl_Load(object sender, EventArgs e)
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

        private void monthView_SelectionChanged(object sender, EventArgs e)
        {
            presenter.OnMonthDaySelected();
        }

        public DateTime GetMonthDaySelected()
        {
            if (InvokeRequired)
            {
                return (DateTime)Invoke(new Func<DateTime>(GetMonthDaySelected));
            }
            return DateTime.Now;
        }

        public void SetEvents(IList<Event> events)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<Event>>(SetEvents), events);
                return;
            }
            foreach (var eventItem in events)
            {
            }
        }
    }
}
