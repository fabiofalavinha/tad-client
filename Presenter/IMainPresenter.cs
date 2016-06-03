namespace TadManagementTool.Presenter
{
    public interface IMainPresenter : IPresenter
    {
        void OnMenuItemSelect(string menuActionTypeViewString);
        void OnUserChangePassword();
    }
}
