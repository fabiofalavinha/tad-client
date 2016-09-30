using System.Collections.Generic;
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
