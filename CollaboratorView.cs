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
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class CollaboratorView : UserControl, ICollaboratorView
    {
        private readonly IMainView parentView;
        private readonly ICollaboratorPresenter presenter;
        private readonly Collaborator collaborator;

        public CollaboratorView(IMainView parentView)
        {
            InitializeComponent();
            this.parentView = parentView;
            this.presenter = new CollaboratorPresenter(this);
        }

        public CollaboratorView(IMainView parentView, Collaborator collaborator)
            : this(parentView)
        {
            this.collaborator = collaborator;
        }

        private void CollaboratorView_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        private void releaseDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            presenter.OnEnableReleaseDateOption();
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

        private void backToListCollaboratorButton_Click(object sender, EventArgs e)
        {
            presenter.OnBackToListCollaboratorView();
        }

        public void OpenListCollaboratorView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenListCollaboratorView));
                return;
            }
            parentView.ShowControlView(new ListCollaboratorUserControl(parentView)
            {
                Dock = DockStyle.Fill
            });
        }

        private void addTelephoneButton_Click(object sender, EventArgs e)
        {
            presenter.OnAddTelephone();
        }

        private void removeTelephoneButton_Click(object sender, EventArgs e)
        {
            presenter.OnRemoveTelephone();
        }

        public void SetPhoneTypeList(IList<PhoneTypeViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<PhoneTypeViewItem>>(SetPhoneTypeList), list);
                return;
            }
            phoneTypeComboBox.Items.Clear();
            phoneTypeComboBox.Items.AddRange(list.ToArray());
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            presenter.OnSave();
        }

        public PhoneTypeViewItem GetPhoneTypeSelected()
        {
            if (InvokeRequired)
            {
                return (PhoneTypeViewItem)Invoke(new Func<PhoneTypeViewItem>(GetPhoneTypeSelected));
            }
            return (PhoneTypeViewItem)phoneTypeComboBox.SelectedItem;
        }

        public string GetPhoneAreaCode()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetPhoneAreaCode));
            }
            return phoneAreaCodeTextBox.Text;
        }

        public string GetPhoneNumber()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetPhoneNumber));
            }
            return phoneNumberTextBox.Text;
        }

        public void SetReleaseDateEnabled(bool enabled)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetReleaseDateEnabled), enabled);
                return;
            }
            releaseDateTimePicker.Enabled = enabled;
        }

        public void AddTelephone(Telephone telephone)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Telephone>(AddTelephone), telephone);
                return;
            }
            telephoneListBox.Items.Add(telephone);
        }

        public void ClearPhoneFields()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(ClearPhoneFields));
                return;
            }
            telephoneListBox.SelectedIndex = -1;
            phoneAreaCodeTextBox.Text = string.Empty;
            phoneNumberTextBox.Text = string.Empty;
        }

        public Telephone GetTelephoneSelected()
        {
            if (InvokeRequired)
            {
                return (Telephone)Invoke(new Func<Telephone>(GetTelephoneSelected));
            }
            return (Telephone)telephoneListBox.SelectedItem;
        }

        public IList<Telephone> GetTelephoneList()
        {
            if (InvokeRequired)
            {
                return (IList<Telephone>)Invoke(new Func<IList<Telephone>>(GetTelephoneList));
            }
            return telephoneListBox.Items.OfType<Telephone>().ToArray();
        }

        public void RemoveTelephone(Telephone telephone)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Telephone>(RemoveTelephone), telephone);
                return;
            }
            telephoneListBox.Items.Remove(telephone);
        }

        public bool ShowBinaryQuestion(string message)
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<string, bool>(ShowBinaryQuestion), message);
            }
            return MessageBox.Show(message, "TAD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public string GetName()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetName));
            }
            return nameTextBox.Text;
        }

        public string GetEmail()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetEmail));
            }
            return emailTextBox.Text;
        }

        public string GetId()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetId));
            }
            return idLabel.Text;
        }

        public bool IsReleaseDateOptionChecked()
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<bool>(IsReleaseDateOptionChecked));
            }
            return releaseDateCheckBox.Checked;
        }

        public DateTime GetBirthDate()
        {
            if (InvokeRequired)
            {
                return (DateTime)Invoke(new Func<DateTime>(GetBirthDate));
            }
            return birthDateTimePicker.Value;
        }

        public GenderType? GetGenderType()
        {
            if (InvokeRequired)
            {
                return (GenderType?)Invoke(new Func<GenderType?>(GetGenderType));
            }
            return maleRadioButton.Checked 
                ? GenderType.Male 
                : femaleRadioButton.Checked 
                    ? GenderType.Female 
                    : (GenderType?)null;
        }

        public DateTime GetStartDate()
        {
            throw new NotImplementedException();
        }

        public DateTime GetReleaseDate()
        {
            throw new NotImplementedException();
        }
    }
}
