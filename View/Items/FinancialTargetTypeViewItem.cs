using System.Collections.Generic;
using System.Linq;
using TadManagementTool.Model.Financial;

namespace TadManagementTool.View.Items
{
    public class FinancialTargetTypeViewItem
    {
        public FinancialTargetType Wrapper { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsAssociatedWithCollaborator { get { return Wrapper == FinancialTargetType.Colaborator; } }

        public FinancialTargetTypeViewItem(FinancialTargetType wrapper, string name)
        {
            Wrapper = wrapper;
            Id = (int)wrapper;
            Name = name;
        }

        public IList<FinancialReferenceOptionViewItem> Filter(IList<FinancialReferenceOptionViewItem> financialReferenceViewItems)
        {
            if (Wrapper == FinancialTargetType.None)
            {
                return new FinancialReferenceOptionViewItem[] { };
            }
            else
            {
                if (Wrapper == FinancialTargetType.Other)
                {
                    return financialReferenceViewItems.Where(r => !r.AssociatedWithCollaborator).ToArray();
                }
                else
                {
                    return financialReferenceViewItems.Where(r => r.AssociatedWithCollaborator).ToArray();
                }
            }
        }
    }
}
