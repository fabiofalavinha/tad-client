using System.Collections.Generic;
using TadManagementTool.View.Items;

namespace TadManagementTool.View
{
    public interface IFinancialEntryEnrollmentView : IDialogView
    {
        bool IsCollaboratorTypeSelected();
        void SetCollaboratorList(IList<FinancialTargetViewItem> list);
        void SetNonCollaboratorList(IList<FinancialTargetViewItem> list);
        void SetFinancialEntry(FinancialEntryViewItem viewItem);
        void SetFinancialReferenceList(IList<FinancialReferenceViewItem> list);
    }
}
