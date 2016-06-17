﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TadManagementTool.Model.Financial;
using TadManagementTool.View.Items;

namespace TadManagementTool.View
{
    public interface IFinancialEntryListView : IControlView
    {
        DialogResult OpenFinancialEntryView();
        DialogResult OpenFinancialEntryView(FinancialEntryViewItem selected);
        DateTime GetFinancialEntryFromDate();
        DateTime GetFinancialEntryToDate();
        FinancialEntryViewItem GetFinancialEntryViewSelected();
        void SetFinancialEntryFilterDateFrom(DateTime date);
        void SetFinancialEntryFilterDateTo(DateTime date);
        void SetFinancialEntryList(IList<FinancialEntryViewItem> list);
        void SetCurrentBalance(Balance balance);
        void SetCurrentBalanceColor(Color color);
    }
}
