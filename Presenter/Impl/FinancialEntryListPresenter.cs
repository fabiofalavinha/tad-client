using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TadManagementTool.Model;
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
                var none = new FinancialTargetTypeViewItem(FinancialTargetType.None, "Todos");
                var collaborator = new FinancialTargetTypeViewItem(FinancialTargetType.Colaborator, "Colaborador");
                var nonCollaborator = new FinancialTargetTypeViewItem(FinancialTargetType.NonColaborator, "Outros");
                View.SetTargetTypeFilterList(new[] { none, collaborator, nonCollaborator });
                View.SetTargetTypeFilterSelected(none);
                var financialRefereceViewItems = financialService.GetFinancialReferences().Select(r => new FinancialReferenceViewItem(r)).ToArray();
                View.SetFinancialReferenceFilterList(financialRefereceViewItems);
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
                    var targetTypeFilter = View.GetTargetTypeFilterSelected();
                    if (targetTypeFilter.Wrapper != FinancialTargetType.None)
                    {
                        list = list.Where(i => i.Target.ToTargetType() == targetTypeFilter.Wrapper).ToArray();
                    }
                    var financialReferenceFilter = View.GetFinancialReferenceFilterSelected();
                    if (financialReferenceFilter != null)
                    {
                        list = list.Where(i => i.Type.Id == financialReferenceFilter.Wrapper.Id).ToArray();
                    }

                    View.SetFinancialEntryList(list.Select(e => FinancialEntryViewItem.FromModel(e)).ToArray());
                    View.SetRemoveFinancialEntryButtonEnabled(false);
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

        public void OnTargetTypeFilterChanged()
        {
            var task = new Task<IList<FinancialReference>>(() =>
            {
                View.ShowWaitingPanel("Filtrando...");
                return financialService.GetFinancialReferences();
            }, TaskCreationOptions.LongRunning);
            task.ContinueWith(t =>
            {
                var list = t.Result;
                var viewItems = list.Select(r => new FinancialReferenceViewItem(r)).ToArray();
                var targetTypeFilterSelected = View.GetTargetTypeFilterSelected();
                var financialReferenceViewItemsFiltered = targetTypeFilterSelected.Filter(viewItems);
                View.SetFinancialReferenceFilterList(financialReferenceViewItemsFiltered);
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage($"Ocorreu um erro ao filtrar os dados de tipo de lançamento. Tente repetir a operação. {innerException.Message}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnCloseFinancialEntryBalance()
        {
            var task = new Task<bool>(() =>
            {
                if (View.ShowBinaryQuestion("Você realmente quer fechar o caixa?"))
                {
                    View.ShowWaitingPanel("Fechando o caixa... ");
                    var loggedUser = UserContext.GetInstance().LoggedUser;
                    financialService.CloseBalance(loggedUser);
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
                    OnSearchFinancialEntries();
                    View.HideWaitingPanel();
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }

        public void OnRemoveOpenedFinancialEntry()
        {
            var task = new Task<bool>(() =>
            {
                if (View.ShowBinaryQuestion("Deseja excluir esse lançamento?"))
                {
                    View.ShowWaitingPanel(string.Format("Excluindo lançamento..."));
                    var financialEntryViewSelected = View.GetFinancialEntryViewSelected();
                    if (financialEntryViewSelected != null)
                    {
                        financialService.RemoveFinancialEntry(financialEntryViewSelected.Wrapper);
                        return true;
                    }
                }
                return false;
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage($"Ocorreu um erro ao remover um lançamento. Tente repetir a operação. {innerException.Message}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                if (t.Result)
                {
                    OnSearchFinancialEntries();
                }
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }

        public void OnSelectedFinancialEntry()
        {
            var selectedFinancialItem = View.GetFinancialEntryViewSelected();
            View.SetRemoveFinancialEntryButtonEnabled(!selectedFinancialItem.Wrapper.Closed);
        }
    }
}
