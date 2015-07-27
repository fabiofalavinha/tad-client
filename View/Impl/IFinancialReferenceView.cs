using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model.Financial;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IFinancialReferenceView : IControlView
    {
        string GetDescription();
        bool GetAssociatedWithCollaboratorChecked();
        CategoryViewItem GetCategorySelected();
        void SetCategoryList(IList<CategoryViewItem> list);
        void SetDescription(string description);
        void SetCategory(Category category);
        void SetAssociatedWithCollaboratorChecked(bool value);
        void OpenFinancialReferenceListView();
    }
}
