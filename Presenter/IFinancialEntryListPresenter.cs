namespace TadManagementTool.Presenter
{
    public interface IFinancialEntryListPresenter : IPresenter
    {
        void OnOpenFinancialEntryView();
        void OnSearchFinancialEntries();
        void OnSelectFinancialEntryView();
    }
}
