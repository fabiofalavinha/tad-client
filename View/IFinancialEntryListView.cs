using System.Collections.Generic;
using TadManagementTool.View.Items;

namespace TadManagementTool.View
{
    public interface IFinancialEntryListView : IControlView
    {
        void SetFinancialReferenceList(IList<FinancialReferenceViewItem> list);
    }
}
