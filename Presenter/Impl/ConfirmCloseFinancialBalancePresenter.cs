using System.Threading.Tasks;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class ConfirmCloseFinancialBalancePresenter : AbstractDialogPresenter<IConfirmCloseFinancialBalanceView>, IConfirmCloseFinancialBalancePresenter
    {
        private readonly FinancialService financialService;

        public ConfirmCloseFinancialBalancePresenter(IConfirmCloseFinancialBalanceView view)
            : base(view)
        {
            financialService = new FinancialService();
        }

        public void InitView()
        {
            var firstOpenedEntry = financialService.GetFirstOpenedFinancialEntry();
            if (firstOpenedEntry != null)
            {
                View.SetEntryMinimumDate(firstOpenedEntry.ToEntryDate());

                var lastOpenedEntry = financialService.GetLastOpenedFinancialEntry();
                if (lastOpenedEntry != null)
                {
                    View.SetEntryMaximumDate(lastOpenedEntry.ToEntryDate());
                }
            }
            else
            {
                View.SetEntryDateEnabled(false);
                View.SetOkButtonEnabled(false);
                View.SetWarningMessage("Não é possível fechar o caixa, pois todos os lançamentos já foram fechados.");
            }
        }

        public void OnCancel()
        {
            View.SetDialogResult(DialogResult.Cancel);
        }

        public void OnOk()
        {
            var task = new Task<bool>(() =>
            {
                if (View.ShowBinaryQuestion("Você realmente quer fechar o caixa?"))
                {
                    View.ShowWaitingPanel("Fechando o caixa... ");
                    var loggedUser = UserContext.GetInstance().LoggedUser;
                    financialService.CloseBalance(loggedUser, View.GetEntryDate());
                    return true;
                }
                return false;
            }, TaskCreationOptions.LongRunning);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage($"Ocorreu um erro ao fechar o caixa. Tente repetir a operação. {innerException.Message}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                if (t.Result)
                {
                    View.HideWaitingPanel();
                    View.SetDialogResult(DialogResult.OK);
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }
    }
}
