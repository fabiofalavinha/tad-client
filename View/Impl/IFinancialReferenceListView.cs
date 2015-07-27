using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model.Financial;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IFinancialReferenceListView : IControlView
    {
        FinancialReferenceViewItem GetFinancialReferenceSelected();
        bool ShowBinaryQuestion(string message);
        void OpenFinancialReferenceEnrollmentView();
        void SetFinancialReferenceList(IList<FinancialReferenceViewItem> list);
    }
}
