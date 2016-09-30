using System.Windows.Forms;

namespace TadManagementTool.View.Impl
{
    public interface INewsletterUserView : IControlView
    {
        string GetName();
        string GetEmail();
        void SetName(string name);
        void SetEmail(string email);
        void SetDialogResult(DialogResult result);
    }
}
