using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.View
{
    public interface IUserChangePasswordView : IDialogView
    {
        string GetCurrentPassword();
        string GetNewPassword();
        string GetConfirmNewPassword();
    }
}
