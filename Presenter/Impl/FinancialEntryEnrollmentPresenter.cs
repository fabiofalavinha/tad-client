using TadManagementTool.View;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class FinancialEntryEnrollmentPresenter : AbstractDialogPresenter<IFinancialEntryEnrollmentView>, IFinancialEntryEnrollmentPresenter
    {
        public FinancialEntryEnrollmentPresenter(IFinancialEntryEnrollmentView view)
            : base(view)
        {
        }

        public void InitView()
        {
        }

        public void InitViewWith(FinancialEntryViewItem viewItem)
        {
        }
    }
}
