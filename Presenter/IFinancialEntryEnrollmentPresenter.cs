using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter
{
    public interface IFinancialEntryEnrollmentPresenter : IPresenter
    {
        void InitViewWith(FinancialEntryViewItem viewItem);
    }
}
