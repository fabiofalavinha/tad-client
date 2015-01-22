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
        DateTime GetBirthDate();
        GenderType? GetGenderType();
        DateTime GetStartDate();
        DateTime GetReleaseDate();
        bool ShowBinaryQuestion(string message);
        void OpenListCollaboratorView();
        void SetPhoneTypeList(IList<PhoneTypeViewItem> list);
        void SetUserRoleList(IList<UserRoleViewItem> list);
        void SetReleaseDateEnabled(bool enabled);
        void AddTelephone(Telephone telephone);
        void RemoveTelephone(Telephone telephone);
        void ClearPhoneFields();
    }
}
