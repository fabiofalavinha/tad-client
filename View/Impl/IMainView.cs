
namespace TadManagementTool.View.Impl
{
    public interface IMainView : IDialogView
    {
        void OpenCollaboratorView();
        void ShowControlView(IControlView controlView);
    }
}
