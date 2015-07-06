
using TadManagementTool.Model;
namespace TadManagementTool.View.Impl
{
    public interface IMainView : IDialogView
    {
        void OpenCollaboratorView();
        void ShowControlView(IControlView controlView);
        void OpenCalendarView();
        void OpenPostListView();
        void OpenImageListView();
        void OpenUserChangePasswordView(User user);
    }
}
