using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TadManagementTool.Model.Financial;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IFinancialEntryListView : IControlView
    {
        DialogResult OpenFinancialEntryView();
        DialogResult OpenFinancialEntryView(FinancialEntryViewItem selected);
        DialogResult OpenConfirmCloseFinancialBalanceView();
        DateTime GetFinancialEntryFromDate();
        DateTime GetFinancialEntryToDate();
        FinancialEntryViewItem GetFinancialEntryViewSelected();
        FinancialTargetTypeViewItem GetTargetTypeFilterSelected();
        ContributorViewItem GetContributorFilterSelected();
        FinancialReferenceOptionViewItem GetFinancialReferenceFilterSelected();
        IList<FinancialEntryViewItem> GetFinancialEntryList();
        void SetFinancialEntryFilterDateFrom(DateTime date);
        void SetFinancialEntryFilterDateTo(DateTime date);
        void SetFinancialEntryList(IList<FinancialEntryViewItem> list);
        void SetFinancialCloseableOptionEnabled(bool enabled);
        void SetCurrentBalance(Balance balance);
        void SetCurrentBalanceColor(Color color);
        void SetTargetTypeFilterList(IList<FinancialTargetTypeViewItem> list);
        void SetFinancialReferenceFilterList(IList<FinancialReferenceOptionViewItem> list);
        void SetTargetTypeFilterSelected(FinancialTargetTypeViewItem selected);
        bool ShowBinaryQuestion(string message);
        void SetRemoveFinancialEntryButtonEnabled(bool enabled);
        string SelectFilePathToSaveExcelFile();
        void ShowSuccessMessage(string message);
        void SetFinancialReferenceFilterOptionEnabled(bool v);
        void SetContributorList(IList<ContributorViewItem> list);
    }
}
