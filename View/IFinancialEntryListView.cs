using System.Collections.Generic;
using System.Windows.Forms;
using TadManagementTool.View.Items;

namespace TadManagementTool.View
{
    public interface IFinancialEntryListView : IControlView
    {
        DialogResult OpenFinancialEntryView();
        void SetFinancialReferenceList(IList<FinancialReferenceViewItem> list);
    }
}
