using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model.Financial
{
    public class FinancialTargetHistoryFilter
    {
        public Period Period { get; set; }

        public FinancialTarget Target { get; set; }

        public FinancialTargetHistoryFilter()
        {
            Period = new Period();
        }
    }
}
