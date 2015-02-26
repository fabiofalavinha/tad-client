
namespace TadManagementTool.View.Impl
{
    public class OpenCalendarMenuViewAction : IMenuActionView
    {
        public void Open(IMainView mainView)
        {
            mainView.OpenCalendarView();
        }
    }
}
