using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                DoSetFinancialEntryDateRange();
                View.SetFinancialReferenceList(financialService.GetFinancialReferences().Select(r => new FinancialReferenceViewItem(r)).ToArray());

                // TODO: search financial entries using initial date (from and to)

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

        private void DoSetFinancialEntryDateRange()
        {
            var today = DateTime.Now;
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            View.SetFinancialEntryFilterDateFrom(firstDayOfMonth);
            View.SetFinancialEntryFilterDateTo(lastDayOfMonth);
        }

        public void OnNewFinancialEntryAdded()
        {
        }

        public void OnOpenFinancialEntryView()
        {
            var result = View.OpenFinancialEntryView();
            if (result == DialogResult.OK)
            {
                // TODO: refresh list
            }
        }

        public void OnSearchFinancialEntries()
        {
            var fromDate = View.GetFinancialEntryFromDate();
            var toDate = View.GetFinancialEntryToDate();
            if (fromDate > toDate)
            {
                View.ShowWarningMessage("Ops... As datas escolhidas para filtrar os lançamentos estão erradas. O primeiro campo de data deve ser menor que o segundo campo de data.");
                return;
            }



        }
    }
}
