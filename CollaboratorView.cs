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
            SetObservationLimit(observationTextBox.MaxLength);
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
            presenter.InitViewWith(collaborator);
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
            if (InvokeRequired)
            {
                return (DateTime)Invoke(new Func<DateTime>(GetStartDate));
            }
            return startDateTimePicker.Value;
        }

        public DateTime GetReleaseDate()
        {
            if (InvokeRequired)
            {
                return (DateTime)Invoke(new Func<DateTime>(GetReleaseDate));
            }
            return releaseDateTimePicker.Value;
        }

        public void SetUserRoleList(IList<UserRoleViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<UserRoleViewItem>>(SetUserRoleList), list);
                return;
            }
            userRoleComboBox.Items.Clear();
            userRoleComboBox.Items.AddRange(list.ToArray());
        }

        public UserRoleViewItem GetUserRoleSelected()
        {
            if (InvokeRequired)
            {
                return (UserRoleViewItem)Invoke(new Func<UserRoleViewItem>(GetUserRoleSelected));
            }
            return (UserRoleViewItem)userRoleComboBox.SelectedItem;
        }

        public void SetUserRole(UserRole userRole)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<UserRole>(SetUserRole), userRole);
                return;
            }
            userRoleComboBox.SelectedItem = userRoleComboBox.Items.Cast<UserRoleViewItem>().SingleOrDefault(i => i.Wrapper == userRole);
        }

        public void SetName(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetName), name);
                return;
            }
            nameTextBox.Text = name;
        }

        public void SetStartDate(DateTime? startDate)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DateTime?>(SetStartDate), startDate);
                return;
            }
            if (startDateCheckBox.Checked = startDate.HasValue)
            {
                startDateTimePicker.Value = startDate.Value;
            }
        }

        public void SetGenderType(GenderType genderType)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<GenderType>(SetGenderType), genderType);
                return;
            }
            maleRadioButton.Checked = genderType == GenderType.Male;
            femaleRadioButton.Checked = genderType == GenderType.Female;
        }

        public void SetBirthDate(DateTime birthDate)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DateTime>(SetBirthDate), birthDate);
                return;
            }
            birthDateTimePicker.Value = birthDate;
        }

        public void SetEmail(string email)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetEmail), email);
                return;
            }
            emailTextBox.Text = email;
        }

        public void SetReleaseDate(DateTime? releaseDate)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DateTime?>(SetReleaseDate), releaseDate);
                return;
            }
            if (releaseDateCheckBox.Checked = releaseDate.HasValue)
            {
                releaseDateTimePicker.Value = releaseDate.Value;
            }
        }

        public void SetTelephoneList(Telephone[] telephones)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Telephone[]>(SetTelephoneList), telephones);
                return;
            }
            telephoneListBox.Items.Clear();
            telephoneListBox.Items.AddRange(telephones);
        }

        public void SetId(string id)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetId), id);
                return;
            }
            idLabel.Text = id;
        }

        private void startDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            presenter.OnEnableStartDateOption();
        }

        public bool IsStartDateOptionChecked()
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(new Func<bool>(IsStartDateOptionChecked));
            }
            return startDateCheckBox.Checked;
        }

        public void SetStartDateEnabled(bool enabled)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetStartDateEnabled), enabled);
                return;
            }
            startDateTimePicker.Enabled = enabled;
        }

        private void userRoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.OnUserRoleChanged();
        }
       
        public void SetStartDateLabelEnabled(bool enabled)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetStartDateLabelEnabled), enabled);
                return;
            }
            startDateLabel.Enabled = enabled;
        }

        public void SetStartCheckBoxEnabled(bool enabled)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetStartCheckBoxEnabled), enabled);
                return;
            }
            startDateCheckBox.Enabled = enabled;
        }

        public void SetReleaseDateLabelEnabled(bool enabled)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetReleaseDateLabelEnabled), enabled);
                return;
            }
            releaseDateLabel.Enabled = enabled;
        }

        public void SetReleaseCheckBoxEnabled(bool enabled)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetReleaseCheckBoxEnabled), enabled);
                return;
            }
            releaseDateCheckBox.Enabled = enabled;
        }

        public string GetObservation()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetObservation));
            }
            return observationTextBox.Text;
        }

        public void SetObservation(string observation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetObservation), observation);
                return;
            }
            observationTextBox.Text = observation;
        }

        private void observationTextBox_TextChanged(object sender, EventArgs e)
        {
            presenter.OnObservationChanged();
        }

        public void SetObservationLimit(int limit)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<int>(SetObservationLimit), limit);
                return;
            }
            observationLimitLabel.Text = string.Format("(Restante de Caracteres: {0})", limit);
        }
    }
}
