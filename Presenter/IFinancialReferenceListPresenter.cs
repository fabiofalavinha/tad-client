using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Presenter
{
    public interface IFinancialReferenceListPresenter : IPresenter
    {
        void OpenFinancialReferenceEnrollmentView();
        void OnRemove();
    }
}
