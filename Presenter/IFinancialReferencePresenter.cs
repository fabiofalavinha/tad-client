using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Presenter
{
    public interface IFinancialReferencePresenter : IPresenter
    {
        void OpenFinancialReferenceListView();
        void OnSave();
    }
}
