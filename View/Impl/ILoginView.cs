
namespace TadManagementTool.View.Impl
{
    public interface ILoginView : IDialogView
    {
        string GetPassword();
        string GetUserName();
        string GetLastUserStored();
        void StoreLastUserName(string lastUserName);
        void SetUserName(string userName);
    }
}
