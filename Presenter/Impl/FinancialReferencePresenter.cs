using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TadManagementTool.Model.Financial;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class FinancialReferencePresenter : AbstractControlPresenter<IFinancialReferenceView>, IFinancialReferencePresenter
    {
        private readonly FinancialService financialService;

        private FinancialReference financialReference;

        public FinancialReferencePresenter(IFinancialReferenceView view)
            : base(view)
        {
            this.financialService = new FinancialService();
        }

        public FinancialReferencePresenter(IFinancialReferenceView view, FinancialReference financialReference)
            : this(view)
        {
            this.financialReference = financialReference;
        }

        public void InitView()
        {
            DoLoadCategoryList();
            if (financialReference != null)
            {
                View.SetDescription(financialReference.Description);
                View.SetCategory(CategoryExtensions.FromValue(financialReference.Category));
                View.SetAssociatedWithCollaboratorChecked(financialReference.AssociatedWithCollaborator);
            }
        }

        private void DoLoadCategoryList()
        {
            var categoryList = new List<CategoryViewItem>();
            categoryList.Add(new CategoryViewItem(Category.Receivable));
            categoryList.Add(new CategoryViewItem(Category.Payable));
            View.SetCategoryList(categoryList);
        }

        public void OpenFinancialReferenceListView()
        {
            View.OpenFinancialReferenceListView();
        }

        public void OnSave()
        {
            var task = new Task<bool>(() =>
            {
                View.ShowWaitingPanel("Salvando tipo de lançamento...");
                var description = View.GetDescription();
                if (string.IsNullOrWhiteSpace(description))
                {
                    View.ShowWarningMessage("É obrigatório informar a descrição");
                    return false;
                }
                var categoryViewItem = View.GetCategorySelected();
                if (categoryViewItem == null)
                {
                    View.ShowWarningMessage("Selecione uma categoria");
                    return false;
                }
                if (financialReference == null)
                    financialReference = new FinancialReference();
                financialReference.Description = description;
                financialReference.Category = (int)categoryViewItem.Wrapper;
                financialReference.AssociatedWithCollaborator = View.GetAssociatedWithCollaboratorChecked();
                financialService.SaveFinancialReference(financialReference);
                return true;
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                if (t.Result)
                {
                    View.OpenFinancialReferenceListView();
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao salvar o tipo de lançamento. Tente repetir a operação. {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }
    }
}
