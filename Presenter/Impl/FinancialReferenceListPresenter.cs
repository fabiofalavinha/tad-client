using System;
using System.Linq;
using System.Threading.Tasks;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class FinancialReferenceListPresenter : AbstractControlPresenter<IFinancialReferenceListView>, IFinancialReferenceListPresenter
    {
        private readonly FinancialService financialService;

        public FinancialReferenceListPresenter(IFinancialReferenceListView view)
            : base(view)
        {
            this.financialService = new FinancialService();
        }

        public void InitView()
        {
            var task = new Task(() =>
            {
                View.ShowWaitingPanel("Carregando a lista de tipos de lançamento...");
                DoLoadFinancialReferenceList();
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao listar os tipos de lançamento. Tente repetir a operação. {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        private void DoLoadFinancialReferenceList()
        {
            var result = financialService.GetFinancialReferences();
            View.SetFinancialReferenceList(result.Select(r => new FinancialReferenceViewItem(r)).ToArray());
        }

        public void OpenFinancialReferenceEnrollmentView()
        {
            var selected = View.GetFinancialReferenceSelected();
            View.OpenFinancialReferenceEnrollmentView(selected);
        }

        public void OnRemove()
        {
            var task = new Task<bool>(() =>
            {
                var selected = View.GetFinancialReferenceSelected();
                if (selected != null)
                {
                    if (View.ShowBinaryQuestion("Deseja apagar este registro?"))
                    {
                        financialService.RemoveFinancialReference(selected.Wrapper);
                        return true;
                    }
                }
                return false;
            });
            task.ContinueWith(t =>
            {
                try
                {
                    if (t.Result)
                    {
                        View.ShowWaitingPanel("Carregando a lista de tipos de lançamento...");
                        DoLoadFinancialReferenceList();
                    }
                }
                catch (Exception ex)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao carregar a lista de tipos de lançamento. Tente repetir a operação. {0}", ex.Message));
                }
                finally
                {
                    View.HideWaitingPanel();
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao remover o tipo de lançamento selecionado. Tente repetir a operação. {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }
    }
}
