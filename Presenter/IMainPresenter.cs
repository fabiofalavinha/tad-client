using TadManagementTool.View;

namespace TadManagementTool.Presenter
{
    public interface IMainPresenter : IPresenter
    {
        void OnMenuItemSelect(IMenuActionView menuActionView);
    }
}
