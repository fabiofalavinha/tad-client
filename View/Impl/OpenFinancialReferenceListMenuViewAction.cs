using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.View.Impl
{
    public class OpenFinancialReferenceListMenuViewAction : IMenuActionView
    {
        public void Open(IMainView mainView)
        {
            mainView.OpenFinancialReferenceListView();
        }
    }
}
