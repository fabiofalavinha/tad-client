using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IFinancialTargetHistoryView : IDialogView
    {
        DateTime GetFinancialHistoryDateFrom();
        DateTime GetFinancialHistoryDateTo();
        FinancialReferenceOptionViewItem GetFinancialReferenceTypeSelected();
        void SetFinancialHistoryFilterDateFrom(DateTime from);
        void SetFinancialHistoryFilterDateTo(DateTime to);
        void SetFinancialHistoryList(IList<FinancialEntryViewItem> list);
        void SetReferenceTypeList(IList<FinancialReferenceOptionViewItem> list);
        void SetReferenceTypeSelected(FinancialReferenceOptionViewItem viewItem);
        void SetTitle(string title);
    }
}
