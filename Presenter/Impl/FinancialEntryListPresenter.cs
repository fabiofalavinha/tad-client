using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TadManagementTool.Model.Financial;
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
            DoLoadCurrentBalance();

            var today = DateTime.Now;
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            View.SetFinancialEntryFilterDateFrom(firstDayOfMonth);
            View.SetFinancialEntryFilterDateTo(lastDayOfMonth);
            var list = financialService.FindFinancialEntryBy(firstDayOfMonth, lastDayOfMonth);
            View.SetFinancialEntryList(list.Select(e => FinancialEntryViewItem.FromModel(e)).ToArray());
        }

        private void DoLoadCurrentBalance()
        {
            var currentBalance = financialService.GetCurrentTotalBalance();
            View.SetCurrentBalance(currentBalance);
            View.SetCurrentBalanceColor(currentBalance.IsPositive ? Color.Blue : Color.Red);
        }

        public void OnOpenFinancialEntryView()
        {
            var result = View.OpenFinancialEntryView();
            if (result == DialogResult.OK)
            {
                OnSearchFinancialEntries();
            }
        }

        public void OnSearchFinancialEntries()
        {
            var task = new Task<IList<FinancialEntry>>(() =>
            {
                var fromDate = View.GetFinancialEntryFromDate();
                var toDate = View.GetFinancialEntryToDate();
                if (fromDate > toDate)
                {
                    View.ShowWarningMessage("Ops... As datas escolhidas para filtrar os lançamentos estão erradas. O primeiro campo de data deve ser menor que o segundo campo de data.");
                    return null;
                }
                View.ShowWaitingPanel($"Buscando lançamentos de {fromDate.ToShortDateString()} até {toDate.ToShortDateString()}...");
                return financialService.FindFinancialEntryBy(fromDate, toDate);
            }, TaskCreationOptions.LongRunning);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage($"Ocorreu um erro ao pesquisar lançamentos. Tente repetir a operação. {innerException.Message}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                var list = t.Result;
                if (list != null)
                {
                    View.SetFinancialEntryList(list.Select(e => FinancialEntryViewItem.FromModel(e)).ToArray());
                }
                DoLoadCurrentBalance();
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }

        public void OnSelectFinancialEntryView()
        {
            var selected = View.GetFinancialEntryViewSelected();
            if (selected != null)
            {
                var result = View.OpenFinancialEntryView(selected);
                if (result == DialogResult.OK)
                {
                    OnSearchFinancialEntries();
                }
            }
        }
    }
}
