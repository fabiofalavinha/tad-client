using System.Windows.Forms;

namespace TadManagementTool.View
{
    public interface IDialogView : IView
    {
        void SetDialogResult(DialogResult dialogResult);
        void CloseView();
    }
}
