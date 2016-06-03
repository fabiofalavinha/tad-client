using System.Linq;
using System.Threading.Tasks;
using TadManagementTool.Service;
using TadManagementTool.View;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class FinancialEntryListPresenter : AbstractControlPresenter<IFinancialEntryListView>, IFinancialEntryListPresenter
    {
        private readonly FinancialService financialService;

        public FinancialEntryListPresenter(IFinancialEntryListView view)
            : base(view)
        {
            financialService = new FinancialService();
        }

        public void InitView()
        {
            var task = new Task(() =>
            {
                View.ShowWaitingPanel("Carregando lançamentos...");
                View.SetFinancialReferenceList(financialService.GetFinancialReferences().Select(r => new FinancialReferenceViewItem(r)).ToArray());
            }, TaskCreationOptions.LongRunning);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage($"Ocorreu um erro ao listar os lançamento. Tente repetir a operação. {innerException.Message}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();

        }

        public void OnNewFinancialEntryAdded()
        {
        }
    }
}
