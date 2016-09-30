using System.Collections.Generic;
using TadManagementTool.Model;

namespace TadManagementTool.View.Impl
{
    public interface ICollaboratorBirthDaysView : IControlView
    {
        void SetBirthdayList(IList<BirthdayList> list);
    }
}
