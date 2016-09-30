namespace TadManagementTool.View
{
    public interface IUserChangePasswordView : IDialogView
    {
        string GetCurrentPassword();
        string GetNewPassword();
        string GetConfirmNewPassword();
    }
}
