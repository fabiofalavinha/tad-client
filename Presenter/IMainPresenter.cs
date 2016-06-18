namespace TadManagementTool.Presenter
{
    public interface IMainPresenter : IPresenter
    {
        void OnMenuItemSelect(string menuActionTypeViewString);
        bool OnMenuItemAccess(string menuActionTypeViewString);
        void OnUserChangePassword();
    }
}
