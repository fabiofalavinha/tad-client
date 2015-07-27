using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class FinancialReferenceListPresenter : AbstractControlPresenter<IFinancialReferenceListView>, IFinancialReferenceListPresenter
    {
        public FinancialReferenceListPresenter(IFinancialReferenceListView view)
            : base(view)
        {
        }

        public void InitView()
        {

        }

        public void OpenFinancialReferenceEnrollmentView()
        {
            View.OpenFinancialReferenceEnrollmentView();
        }
    }
}
