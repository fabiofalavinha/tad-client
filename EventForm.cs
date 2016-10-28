using System;
using System.Collections.Generic;
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
    public partial class EventForm : Form, IEventEnrollmentView
    {
        private readonly IEventEnrollmentPresenter presenter;

        public EventResult EventResult { get; set; }

        public EventForm()
            : this(null)
        {
        }

        public EventForm(Event editedEvent)
        {
            InitializeComponent();
            presenter = new EventEnrollmentPresenter(this, editedEvent);
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

        public void SetEventTitle(string title)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetEventTitle), title);
                return;
            }
            eventTitleTextBox.Text = title;
        }

        public void SetEventDate(DateTime date)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DateTime>(SetEventDate), date);
                return;
            }
            eventDateTimePicker.Value = date;
        }

        public void SetEventNotes(string notes)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetEventNotes), notes);
                return;
            }
            eventNotesTextBox.Text = notes;
        }

        public void SetEventVisibility(VisibilityType visibilityType)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<VisibilityType>(SetEventVisibility), visibilityType);
                return;
            }
            eventPublicVisibilityRadioButton.Checked = visibilityType == VisibilityType.Public;
            eventInternalVisibilityRadioButton.Checked = visibilityType == VisibilityType.Internal;
        }

        private void removeEventButton_Click(object sender, EventArgs e)
        {
            presenter.OnRemoveEvent();
        }

        public bool ShowBinaryQuestion(string message)
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<string, bool>(ShowBinaryQuestion), message);
            }
            return MessageBox.Show(message, "TAD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public void SetRemoveButtonVisible(bool visible)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetRemoveButtonVisible), visible);
                return;
            }
            removeEventButton.Visible = visible;
        }

        private void eventBackColorValueLabel_Click(object sender, EventArgs e)
        {
            presenter.OnSelectEventBackColor();
        }

        private void eventFontColorValueLabel_Click(object sender, EventArgs e)
        {
            presenter.OnSelectEventFontColor();
        }


        public Color? SelectEventBackColor()
        {
            if (InvokeRequired)
            {
                return (Color?)Invoke(new Func<Color?>(SelectEventBackColor));
            }
            if (backColorDialog.ShowDialog() == DialogResult.OK)
            {
                return backColorDialog.Color;
            }
            return null;
        }

        public Color? SelectEventFontColor()
        {
            if (InvokeRequired)
            {
                return (Color?)Invoke(new Func<Color?>(SelectEventFontColor));
            }
            if (fontColorDialog.ShowDialog() == DialogResult.OK)
            {
                return fontColorDialog.Color;
            }
            return null;
        }

        public void SetEventBackColor(Color color)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Color>(SetEventBackColor), color);
                return;
            }
            eventBackColorValueLabel.BackColor = color;
        }

        public void SetEventFontColor(Color color)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Color>(SetEventFontColor), color);
                return;
            }
            eventFontColorValueLabel.BackColor = color;
        }

        public Color GetEventBackColor()
        {
            if (InvokeRequired)
            {
                return (Color)Invoke(new Func<Color>(GetEventBackColor));
            }
            return eventBackColorValueLabel.BackColor;
        }

        public Color GetEventFontColor()
        {
            if (InvokeRequired)
            {
                return (Color)Invoke(new Func<Color>(GetEventFontColor));
            }
            return eventFontColorValueLabel.BackColor;
        }

        private void eventInternalVisibilityRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            presenter.OnInternalVisibilitySelected();
        }

        private void eventPublicVisibilityRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            presenter.OnPublicVisibilitySelected();
        }

        public void SetCategoryVisible(bool visible)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetCategoryVisible), visible);
                return;
            }
            categoryLabel.Visible = visible;
            categoryComboBox.Visible = visible;
            categoryComboBox.SelectedIndex = -1;
        }

        public void SetCategoryList(IList<EventCategoryViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<EventCategoryViewItem>>(SetCategoryList), list);
                return;
            }
            categoryComboBox.Items.Clear();
            categoryComboBox.Items.AddRange(list.ToArray());
        }

        public EventCategoryViewItem GetEventCategory()
        {
            if (InvokeRequired)
            {
                return (EventCategoryViewItem)Invoke(new Func<EventCategoryViewItem>(GetEventCategory));
            }
            return (EventCategoryViewItem)categoryComboBox.SelectedItem;
        }

        public void SetEventCategory(EventCategoryViewItem viewItem)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<EventCategoryViewItem>(SetEventCategory), viewItem);
                return;
            }
            var found = categoryComboBox.Items.Cast<EventCategoryViewItem>().SingleOrDefault(i => i.Id.Equals(viewItem.Id));
            if (found != null)
            {
                categoryComboBox.SelectedItem = found;
            }
        }

        private void openConsecrationDetailsButton_Click(object sender, EventArgs e)
        {
            presenter.OnOpenConsecrationView();
        }

        public void OpenConsecrationView(Event currentEvent)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Event>(OpenConsecrationView), currentEvent);
                return;
            }
            using (var form = new ConsecrationEnrollmentForm(currentEvent))
            {
                form.ShowDialog();
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.OnCategorySelection();
        }

        public void SetConsecrationDetailsButtonVisible(bool visible)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetConsecrationDetailsButtonVisible), visible);
                return;
            }
            openConsecrationDetailsButton.Visible = visible;
        }
    }
}
