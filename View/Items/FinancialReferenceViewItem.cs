using TadManagementTool.Model.Financial;

namespace TadManagementTool.View.Items
{
    public class FinancialReferenceViewItem
    {
        public FinancialReference Wrapper { get; private set; }

        public string Id { get { return Wrapper.Id; } }
        public string Description { get { return Wrapper.Description; } }
        public string Category { get { return CategoryExtensions.FromValue(Wrapper.Category).Translate(); } }
        public bool AssociatedWithCollaborator { get { return Wrapper.AssociatedWithCollaborator; } }

        public FinancialReferenceViewItem(FinancialReference wrapper)
        {
            Wrapper = wrapper;
        }
    }

    public class AllOptionFinancialReferenceViewItem : FinancialReferenceOptionViewItem
    {
        public AllOptionFinancialReferenceViewItem()
        {
            Id = "-1";
            Description = "Todos";
            IsAllOption = true;
        }
    }
}
