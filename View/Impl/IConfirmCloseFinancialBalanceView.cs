using System;

namespace TadManagementTool.View.Impl
{
    public interface IConfirmCloseFinancialBalanceView : IDialogView
    {
        void SetEntryMinimumDate(DateTime dateTime);
        void SetEntryMaximumDate(DateTime dateTime);
        void SetEntryDateEnabled(bool v);
        void SetOkButtonEnabled(bool v);
        void SetWarningMessage(string v);
        bool ShowBinaryQuestion(string v);
        DateTime GetEntryDate();
    }
}
