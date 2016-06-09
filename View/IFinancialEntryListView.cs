using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TadManagementTool.View.Items;

namespace TadManagementTool.View
{
    public interface IFinancialEntryListView : IControlView
    {
        DialogResult OpenFinancialEntryView();
        DateTime GetFinancialEntryFromDate();
        DateTime GetFinancialEntryToDate();
        void SetFinancialReferenceList(IList<FinancialReferenceViewItem> list);
        void SetFinancialEntryFilterDateFrom(DateTime date);
        void SetFinancialEntryFilterDateTo(DateTime date);
    }
}
