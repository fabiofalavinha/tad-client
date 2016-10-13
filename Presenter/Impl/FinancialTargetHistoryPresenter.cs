using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TadManagementTool.Model.Financial;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class FinancialTargetHistoryPresenter : AbstractDialogPresenter<IFinancialTargetHistoryView>, IFinancialTargetHistoryPresenter
    {
        private readonly FinancialTargetHistoryFilter filter;
        private readonly FinancialService financialService;

        public FinancialTargetHistoryPresenter(IFinancialTargetHistoryView view, FinancialTargetHistoryFilter filter)
            : base(view)
        {
            this.filter = filter;
            financialService = new FinancialService();
        }

        public void InitView()
        {
            var task = new Task(() =>
            {
                View.ShowWaitingPanel("Carregando histórico de lançamentos...");
                View.SetTitle(filter.Target.Name);
                DoSetFinancialHistoryList();
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage($"Ocorreu um erro ao carregar o histórico. Tente repetir a operação. {innerException.Message}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }

        public void OnSearchFinancialHistoryList()
        {
            var task = new Task<IList<FinancialEntry>>(() =>
            {
                var fromDate = View.GetFinancialHistoryDateFrom();
                var toDate = View.GetFinancialHistoryDateTo();
                if(fromDate > toDate)
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
                    View.ShowErrorMessage($"Ocorreu um erro ao tentar filtrar os lançamentos. Tente repetir a operação. {innerException.Message}");
                }
            },TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                var list = t.Result;
                if (list != null)
                {
                    list = list.Where(e => e.Target.Id.Equals(filter.Target.Id)).ToList();

                    var financialReferenceFilter = View.GetFinancialReferenceTypeSelected();
                    if (financialReferenceFilter != null && !financialReferenceFilter.IsAllOption)
                    {
                        list = list.Where(e => e.Type.Id.Equals(financialReferenceFilter.Id)).ToList();
                    }

                    View.SetFinancialHistoryList(list.Select(i => FinancialEntryViewItem.FromModel(i)).ToList());
                }
                View.HideWaitingPanel();
            },TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }

        private void DoSetFinancialHistoryList()
        {
            var period = filter.Period;
            View.SetFinancialHistoryFilterDateFrom(period.From);
            View.SetFinancialHistoryFilterDateTo(period.To);

            var financialReferenceViewItems = 
                financialService.GetFinancialReferences()
                    .Select(r => new FinancialReferenceOptionViewItem() { Id = r.Id, Description = r.Description, AssociatedWithCollaborator = r.AssociatedWithCollaborator })
                    .ToList();
            if (filter.Target.ToTargetType() == FinancialTargetType.Other)
            {
                financialReferenceViewItems = financialReferenceViewItems.Where(r => !r.AssociatedWithCollaborator).ToList();
            }
            else
            {
                financialReferenceViewItems = financialReferenceViewItems.Where(r => r.AssociatedWithCollaborator).ToList();
            }
            var allOption = new AllOptionFinancialReferenceViewItem();
            financialReferenceViewItems.Insert(0, allOption);
            View.SetReferenceTypeList(financialReferenceViewItems);
            View.SetReferenceTypeSelected(allOption);

            var list = financialService.FindFinancialEntryBy(period.From, period.To);
            list = list.Where(e => e.Target.Id.Equals(filter.Target.Id)).ToArray();
            View.SetFinancialHistoryList(list.Select(i => FinancialEntryViewItem.FromModel(i)).ToArray());
        }
    }
}
