using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.Presenter
{
    public interface IEventEnrollmentPresenter : IPresenter
    {
        void OnCancel();
        void OnOk();
        void OnRemoveEvent();
    }
}
