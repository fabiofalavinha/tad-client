﻿using System;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;

namespace TadManagementTool
{
    public partial class EventForm : Form, IEventEnrollmentView
    {
        private readonly IEventEnrollmentPresenter presenter;

        public Event EventResult { get; set; }

        public EventForm()
        {
            InitializeComponent();
            presenter = new EventEnrollmentPresenter(this);
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            presenter.OnCancel();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            presenter.OnOk();
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

        public void SetDialogResult(DialogResult dialogResult)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DialogResult>(SetDialogResult), dialogResult);
                return;
            }
            DialogResult = dialogResult;
        }

        public void CloseView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(CloseView));
                return;
            }
            Close();
        }

        public string GetEventTitle()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetEventTitle));
            }
            return eventTitleTextBox.Text;
        }

        public DateTime GetEventDate()
        {
            if (InvokeRequired)
            {
                return (DateTime)Invoke(new Func<DateTime>(GetEventDate));
            }
            return eventDateTimePicker.Value;
        }

        public string GetEventNotes()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetEventNotes));
            }
            return eventNotesTextBox.Text;
        }

        public VisibilityType GetEventVisibility()
        {
            if (InvokeRequired)
            {
                return (VisibilityType)Invoke(new Func<VisibilityType>(GetEventVisibility));
            }
            if (eventPublicVisibilityRadioButton.Checked)
            {
                return VisibilityType.Public;
            }
            else if (eventInternalVisibilityRadioButton.Checked)
            {
                return VisibilityType.Internal;
            }
            throw new Exception("Unknown visibility type");
        }
    }
}