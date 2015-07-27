using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model.Financial;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class FinancialReferencePresenter : AbstractControlPresenter<IFinancialReferenceView>, IFinancialReferencePresenter
    {
        public FinancialReferencePresenter(IFinancialReferenceView view)
            : base(view)
        {
        }

        public void InitView()
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
        }
    }
}
