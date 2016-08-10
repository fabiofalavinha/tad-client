using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface ICollaboratorView : IControlView
    {
        Telephone GetTelephoneSelected();
        PhoneTypeViewItem GetPhoneTypeSelected();
        UserRoleViewItem GetUserRoleSelected();
        IList<Telephone> GetTelephoneList();
        string GetPhoneAreaCode();
        string GetPhoneNumber();
        string GetName();
        string GetEmail();
        string GetId();
        bool IsReleaseDateOptionChecked();
        bool IsStartDateOptionChecked();
        DateTime GetBirthDate();
        GenderType? GetGenderType();
        DateTime GetStartDate();
        DateTime GetReleaseDate();
        string GetObservation();
        bool ShowBinaryQuestion(string message);
        void SetObservation(string observation);
        void OpenListCollaboratorView();
        void SetPhoneTypeList(IList<PhoneTypeViewItem> list);
        void SetUserRoleList(IList<UserRoleViewItem> list);
        void AddTelephone(Telephone telephone);
        void RemoveTelephone(Telephone telephone);
        void ClearPhoneFields();
        void SetUserRole(UserRole userRole);
        void SetName(string name);
        void SetStartDate(DateTime? startDate);
        void SetGenderType(GenderType genderType);
        void SetBirthDate(DateTime birthDate);
        void SetEmail(string email);
        void SetReleaseDate(DateTime? releaseDate);
        void SetTelephoneList(Telephone[] telephones);
        void SetId(string id);
        void SetStartDateEnabled(bool enabled);
        void SetStartDateLabelEnabled(bool enabled);
        void SetStartCheckBoxEnabled(bool enabled);
        void SetReleaseDateEnabled(bool enabled);
        void SetReleaseCheckBoxEnabled(bool enabled);
        void SetReleaseDateLabelEnabled(bool enabled);
        void SetObservationLimit(int v);
    }
}
