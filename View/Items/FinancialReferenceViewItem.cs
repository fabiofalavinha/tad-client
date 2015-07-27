using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model.Financial;

namespace TadManagementTool.View.Items
{
    public class FinancialReferenceViewItem
    {
        public FinancialReference Wrapper { get; private set; }

        public string Description { get { return Wrapper.Description; } }
        public string Category { get { return CategoryExtensions.FromValue(Wrapper.Category).Translate(); } }
        public bool AssociatedWithCollaborator { get { return Wrapper.AssociatedWithCollaborator; } }

        public FinancialReferenceViewItem(FinancialReference wrapper)
        {
            Wrapper = wrapper;
        }
    }
}
