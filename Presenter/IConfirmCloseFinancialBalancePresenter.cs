namespace TadManagementTool.Presenter
{
    public interface IConfirmCloseFinancialBalancePresenter : IPresenter
    {
        void OnCancel();
        void OnOk();
    }
}
