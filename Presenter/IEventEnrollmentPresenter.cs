using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Presenter
{
    public interface IEventEnrollmentPresenter : IPresenter
    {
        void OnCancel();

        void OnOk();
    }
}
