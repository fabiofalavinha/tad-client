namespace TadManagementTool.View
{
    public interface IView
    {
        void ShowWarningMessage(string message);
        void ShowErrorMessage(string message);
        void ShowWaitingPanel(string message = null);
        void HideWaitingPanel();
    }
}
