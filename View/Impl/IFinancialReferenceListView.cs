using System.Collections.Generic;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IFinancialReferenceListView : IControlView
    {
        FinancialReferenceViewItem GetFinancialReferenceSelected();
        bool ShowBinaryQuestion(string message);
        void OpenFinancialReferenceEnrollmentView(FinancialReferenceViewItem selected);
        void SetFinancialReferenceList(IList<FinancialReferenceViewItem> list);
    }
}
