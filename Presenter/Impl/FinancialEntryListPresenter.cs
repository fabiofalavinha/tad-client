using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Model.Financial;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class FinancialEntryListPresenter : AbstractControlPresenter<IFinancialEntryListView>, IFinancialEntryListPresenter
    {
        private readonly FinancialService financialService;
        private readonly CollaboratorService collaboratorService;

        private bool displayBalance = false;

        public FinancialEntryListPresenter(IFinancialEntryListView view)
            : base(view)
        {
            financialService = new FinancialService();
            collaboratorService = new CollaboratorService();
        }

        public void InitView()
        {
            var task = new Task(() =>
            {
                View.ShowWaitingPanel("Carregando lançamentos...");
                View.SetFinancialCloseableOptionEnabled(UserContext.GetInstance().LoggedUser.IsAdministratorProfile);
                DoSetFinancialEntryDateRange();
                var all = new FinancialTargetTypeViewItem(FinancialTargetType.None, "Todos");
                var collaborator = new FinancialTargetTypeViewItem(FinancialTargetType.Colaborator, "Colaborador");
                var nonCollaborator = new FinancialTargetTypeViewItem(FinancialTargetType.NonColaborator, "Não Colaborador");
                var other = new FinancialTargetTypeViewItem(FinancialTargetType.Other, "Outros");
                View.SetTargetTypeFilterList(new[] { all, collaborator, nonCollaborator, other });
                View.SetTargetTypeFilterSelected(all);
                var financialRefereceViewItems = GetFinancialReferenceList();
                View.SetFinancialReferenceFilterList(financialRefereceViewItems);
                View.SetFinancialReferenceFilterOptionEnabled(false);
                var contributors = collaboratorService.FindAll().Where(c => c.Contributor).Select(c => new ContributorViewItem(c)).ToList();
                contributors.Insert(0, new AllContributorViewItem());
                View.SetContributorList(contributors);
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
            var task = new Task<DialogResult>(() =>
            {
                return View.OpenFinancialEntryView();
            }, TaskCreationOptions.LongRunning);
            task.ContinueWith(t =>
            {
                if (t.Result == DialogResult.OK)
                {
                    OnSearchFinancialEntries();
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
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
                    var contributorViewItem = View.GetContributorFilterSelected();
                    if (!contributorViewItem.IsAllOption)
                    {
                        list = list.Where(e => e.Target.Id.Equals(contributorViewItem.Id)).ToArray();
                    }
                    var targetTypeFilter = View.GetTargetTypeFilterSelected();
                    if (targetTypeFilter.Wrapper != FinancialTargetType.None)
                    {
                        list = list.Where(i => i.Target.ToTargetType() == targetTypeFilter.Wrapper).ToArray();
                    }
                    var financialReferenceFilter = View.GetFinancialReferenceFilterSelected();
                    if (financialReferenceFilter != null && !financialReferenceFilter.IsAllOption)
                    {
                        list = list.Where(i => i.Type.Id.Equals(financialReferenceFilter.Id)).ToArray();
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

        private IList<FinancialReferenceOptionViewItem> GetFinancialReferenceList()
        {
            return financialService.GetFinancialReferences().Select(r => new FinancialReferenceOptionViewItem() { Id = r.Id, Description = r.Description, AssociatedWithCollaborator = r.AssociatedWithCollaborator }).ToArray();
        }

        public void OnTargetTypeFilterChanged()
        {
            var task = new Task<IList<FinancialReferenceOptionViewItem>>(() =>
            {
                View.ShowWaitingPanel("Filtrando...");
                return GetFinancialReferenceList();
            }, TaskCreationOptions.LongRunning);
            task.ContinueWith(t =>
            {
                var list = t.Result;
                var targetTypeFilterSelected = View.GetTargetTypeFilterSelected();
                var filteredList = targetTypeFilterSelected.Filter(list);
                View.SetFinancialReferenceFilterList(filteredList);
                View.SetFinancialReferenceFilterOptionEnabled(targetTypeFilterSelected.Wrapper != FinancialTargetType.None);
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
            var result = View.OpenConfirmCloseFinancialBalanceView();
            if (result == DialogResult.OK)
            {
                OnSearchFinancialEntries();
            }
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

        public void OnExportToExcel()
        {
            var task = new Task<string>(() =>
            {
                var filePath = View.SelectFilePathToSaveExcelFile();
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    View.ShowWaitingPanel("Exportando lista de colaboradores para excel...");
                    financialService.ExportToExcel(View.GetFinancialEntryList().Select(i => i.Wrapper).ToArray(), filePath);
                    return filePath;
                }
                return string.Empty;
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                var filePathResult = t.Result;
                if (!string.IsNullOrEmpty(filePathResult))
                {
                    View.ShowSuccessMessage(string.Format("Planilha excel foi gerada em '{0}'", filePathResult));
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao excluir o lançamento: {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();

        }

        public void OnSendFinancialReceipt()
        {
            var task = new Task<FinancialReceiptResult>(() =>
            {
                var result = new FinancialReceiptResult();
                var viewItem = View.GetFinancialEntryViewSelected();
                if (viewItem.Wrapper.Type.AssociatedWithCollaborator)
                {
                    if (View.ShowBinaryQuestion("Deseja enviar o recibo?"))
                    {
                        View.ShowWaitingPanel("Enviando o recibo...");
                        result.Value = financialService.SendReceipt(viewItem.Wrapper);
                        result.Success = true;
                    }
                    else
                    {
                        result.Success = false;
                    }
                }
                return result;
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                var financialReceiptResult = t.Result;
                if (financialReceiptResult.Success.HasValue)
                {
                    if (financialReceiptResult.Success.Value)
                    {
                        var financialReceipt = financialReceiptResult.Value;
                        View.ShowSuccessMessage(
                            string.Format("O recibo {0} foi enviado para {1} referente a {2} com valor de {3}",
                            financialReceipt.Id, financialReceipt.Target.Name, financialReceipt.Entry.Type.Description, financialReceipt.Entry.Value.ToString("C", new CultureInfo("pt-BR"))));
                    }
                    else
                    {
                        View.ShowWarningMessage("Operação de envio de recibo foi cancelada!");
                    }
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao enviar o recibo: {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnDisplayBalance()
        {
            displayBalance = !displayBalance;
            if (displayBalance)
            {
                View.ShowBalance();
            }
            else
            {
                View.HideBalance();
            }
        }

        private class FinancialReceiptResult
        {
            public FinancialReceipt Value { get; set; }
            public bool? Success { get; set; }
        }
    }
}
