using System;
using System.Collections.Generic;
using System.Drawing;
using TadManagementTool.Model.Financial;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IFinancialEntryEnrollmentView : IDialogView
    {
        bool IsCollaboratorTypeSelected();
        bool IsNonCollaboratorTypeSelected();
        string GetAdditionalText();
        string GetEntryPreviewValue();
        string GetFinancialEntryValue();
        string GetEntryDateAsString(string formatter);
        FinancialTargetType? GetEntryTargetType();
        FinancialTargetViewItem GetEntryTarget();
        FinancialReferenceViewItem GetEntryReference();
        void SetCollaboratorList(IList<FinancialTargetViewItem> list);
        void SetOtherCollaboratorList(IList<FinancialTargetViewItem> list);
        void SetFinancialEntry(FinancialEntryViewItem viewItem);
        void SetFinancialReferenceList(IList<FinancialReferenceViewItem> list);
        void SetCurrentBalance(string value);
        void SetEntryPreviewValue(string previewValue);
        void SetEntryValue(decimal value);
        void SetEntryPreviewValueColor(Color color);
        void SetCategoryType(Category category);
        void SetEntryDateOptionEnabled(bool enabled);
        void SetFinancialEntryDataEnabled(bool enabled);
        void SetNonCollaboratorList(IList<FinancialTargetViewItem> viewItems);
        void SetFinancialEntryMinimumDate(DateTime dateTime);
        void OpenHistoryView(FinancialTargetHistoryFilter filter);
        void SetHistoryButtonVisible(bool visible);
    }
}
