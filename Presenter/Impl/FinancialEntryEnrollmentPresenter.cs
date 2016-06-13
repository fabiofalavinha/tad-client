using System;
using System.Linq;
using System.Threading.Tasks;
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
                View.SetFinancialEntry(viewItem);
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
            View.SetFinancialReferenceList(financialService.GetFinancialReferences().Select(r => new FinancialReferenceViewItem(r)).ToArray());
        }

        private void DoLoadTargetLists()
        {
            try
            {
                currentFinancialTargetViewItems = financialService.FindTargets().Select(t => new FinancialTargetViewItem() { Id = t.Reference, Name = t.Description }).ToArray();
            }
            catch (Exception)
            {
                currentFinancialTargetViewItems = new FinancialTargetViewItem[] { };
            }
            try
            {
                currentCollaboratorViewItems = collaboratorService.FindAll().Select(c => new FinancialTargetViewItem() { Id = c.Id, Name = c.Name }).ToArray();
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
            }
            else
            {
                View.SetNonCollaboratorList(currentFinancialTargetViewItems);
            }
        }

        public void OnSaveFinancialEntry()
        {

        }
    }
}
