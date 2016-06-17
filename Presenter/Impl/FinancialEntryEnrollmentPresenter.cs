using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using TadManagementTool.Model.Financial;
using TadManagementTool.Service;
using TadManagementTool.View;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class FinancialEntryEnrollmentPresenter : AbstractDialogPresenter<IFinancialEntryEnrollmentView>, IFinancialEntryEnrollmentPresenter
    {
        private readonly FinancialService financialService;
        private readonly CollaboratorService collaboratorService;

        private FinancialTargetViewItem[] currentCollaboratorViewItems;
        private FinancialTargetViewItem[] currentFinancialTargetViewItems;
        private FinancialEntryViewItem currentFinancialEntryViewItem;
        private FinancialReferenceViewItem[] currentFinancialReferenceViewItems;

        private decimal currentBalance;

        public FinancialEntryEnrollmentPresenter(IFinancialEntryEnrollmentView view)
            : base(view)
        {
            financialService = new FinancialService();
            collaboratorService = new CollaboratorService();
        }

        public void InitView()
        {
            var task = new Task(() =>
            {
                View.ShowWaitingPanel("Carregando dados financeiros...");
                DoLoadTargetLists();
                DoLoadFinancialReferenceList();
                currentBalance = financialService.GetCurrentTotalBalance().Value;
                View.SetCurrentBalance(currentBalance.ToString());
                View.SetEntryPreviewValue(currentBalance.ToString());
            }, TaskCreationOptions.LongRunning);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage($"Ocorreu um erro ao carregar dados para lançamento financeiro. Tente repetir a operação. {innerException.Message}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }

        public void InitViewWith(FinancialEntryViewItem viewItem)
        {
            var task = new Task(() =>
            {
                View.ShowWaitingPanel("Carregando dados financeiros...");
                DoLoadTargetLists();
                DoLoadFinancialReferenceList();
                currentBalance = financialService.GetCurrentTotalBalance().Value;
                View.SetFinancialEntry(viewItem);
                currentFinancialEntryViewItem = viewItem;
            }, TaskCreationOptions.LongRunning);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage($"Ocorreu um erro ao carregar dados para lançamento financeiro. Tente repetir a operação. {innerException.Message}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }

        private void DoLoadFinancialReferenceList()
        {
            currentFinancialReferenceViewItems = financialService.GetFinancialReferences().Select(r => new FinancialReferenceViewItem(r)).ToArray();
        }

        private void DoLoadTargetLists()
        {
            try
            {
                currentFinancialTargetViewItems = financialService.FindTargets().Select(t => new FinancialTargetViewItem() { Id = t.Id, Name = t.Name }).ToArray();
            }
            catch (Exception)
            {
                currentFinancialTargetViewItems = new FinancialTargetViewItem[] { };
            }
            try
            {
                currentCollaboratorViewItems = collaboratorService.FindAll().Where(c => c.Active).Select(c => new FinancialTargetViewItem() { Id = c.Id, Name = c.Name }).ToArray();
            }
            catch (Exception)
            {
                currentCollaboratorViewItems = new FinancialTargetViewItem[] { };
            }
        }

        public void OnCollaboratorTypeSelection()
        {
            if (View.IsCollaboratorTypeSelected())
            {
                View.SetCollaboratorList(currentCollaboratorViewItems);
                View.SetFinancialReferenceList(currentFinancialReferenceViewItems.Where(r => r.AssociatedWithCollaborator).ToArray());
            }
            else
            {
                View.SetNonCollaboratorList(currentFinancialTargetViewItems);
                View.SetFinancialReferenceList(currentFinancialReferenceViewItems.Where(r => !r.AssociatedWithCollaborator).ToArray());
            }
        }

        public void OnSaveFinancialEntry()
        {
            var task = new Task<bool>(() =>
            {
                View.ShowWaitingPanel("Salvando lançamento financeiro...");

                var balanceInTime = currentBalance;

                var financialEntry = new FinancialEntry();
                if (currentFinancialEntryViewItem != null)
                {
                    financialEntry = currentFinancialEntryViewItem.Wrapper;
                    balanceInTime = financialEntry.Balance.Value;
                }

                financialEntry.DateString = View.GetEntryDateAsString("yyyy-MM-dd");

                var targetType = View.GetEntryTargetType();
                if (!targetType.HasValue)
                {
                    View.ShowWarningMessage("Selecione o tipo da origem");
                    return false;
                }
                var target = View.GetEntryTarget();
                if (target == null)
                {
                    View.ShowWarningMessage($"Selecione a origem");
                    return false;
                }
                financialEntry.Target = new FinancialTarget()
                {
                    Id = target.Id,
                    Name = target.Name,
                    Type = (int)targetType.Value
                };

                var type = View.GetEntryReference();
                if (type == null)
                {
                    View.ShowWarningMessage("Selecion o tipo de lançamento");
                    return false;
                }
                financialEntry.Type = type.Wrapper;

                financialEntry.AdditionalText = View.GetAdditionalText();

                financialEntry.Balance = new Balance()
                {
                    Value = balanceInTime
                };

                var entryValue = decimal.Parse(View.GetFinancialEntryValue());
                if (entryValue == 0)
                {
                    View.ShowWarningMessage("Informe um valor válido para o lançamento");
                    return false;
                }

                financialEntry.Value = decimal.Parse(View.GetFinancialEntryValue());

                financialEntry.PreviewBalance = new Balance()
                {
                    Value = decimal.Parse(View.GetEntryPreviewValue())
                };

                financialService.SaveFinancialEntry(financialEntry);

                return true;
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage($"Ocorreu um erro ao salvar dados do lançamento financeiro. Tente repetir a operação. {innerException.Message}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                if (t.Result)
                {
                    View.CloseView();
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }

        public void OnEntryValueChanged()
        {
            var previewValueAsString = View.GetEntryPreviewValue();
            var entryValueAsString = View.GetFinancialEntryValue();
            if (!string.IsNullOrWhiteSpace(entryValueAsString))
            {
                decimal entryValue;
                if (decimal.TryParse(entryValueAsString, out entryValue))
                {
                    var type = View.GetEntryReference();
                    if (type != null)
                    {
                        DoCalculatePreviewBalance(entryValue, type.Wrapper.ToCategory());
                    }
                    else
                    {
                        View.ShowWarningMessage("Selecione o tipo de lançamento");
                        View.SetEntryPreviewValue(currentBalance.ToString());
                        View.SetEntryPreviewValueColor(Color.Black);
                        View.SetEntryValue(0);
                    }
                }
                else
                {
                    View.ShowWarningMessage("O valor digitado é inválido");
                    View.SetEntryPreviewValue(currentBalance.ToString());
                    View.SetEntryPreviewValueColor(Color.Black);
                    View.SetEntryValue(0);
                }
            }
            else
            {
                View.SetEntryPreviewValue(currentBalance.ToString());
                View.SetEntryPreviewValueColor(Color.Black);
            }
        }

        private void DoCalculatePreviewBalance(decimal? entryValue, Category? entryCategory)
        {
            decimal previewValue = 0;
            if (entryCategory == Category.Payable)
            {
                previewValue = currentBalance - entryValue.Value;
            }
            else if (entryCategory == Category.Receivable)
            {
                previewValue = currentBalance + entryValue.Value;
            }
            View.SetEntryPreviewValue(previewValue.ToString());
            View.SetEntryPreviewValueColor(previewValue == currentBalance ? Color.Black : previewValue >= 0 ? Color.Blue : Color.Red);
        }

        public void OnFinancialReferenceSelected()
        {
            var type = View.GetEntryReference();
            View.SetCategoryType(type.Wrapper.ToCategory());
        }
    }
}
