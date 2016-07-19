using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model.Financial;

namespace TadManagementTool.View.Items
{
    public class FinancialTargetTypeViewItem
    {
        public FinancialTargetType Wrapper { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }

        public FinancialTargetTypeViewItem(FinancialTargetType wrapper, string name)
        {
            Wrapper = wrapper;
            Id = (int)wrapper;
            Name = name;
        }
    }
}
