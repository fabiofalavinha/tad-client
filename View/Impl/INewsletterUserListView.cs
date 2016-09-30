using System.Collections.Generic;
using System.Windows.Forms;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface INewsletterUserViewItem : IControlView
    {
        NewsletterUserViewItem GetNewsletterUserSelected();
        void SetNewsletterUserList(IList<NewsletterUserViewItem> list);
        bool ShowBinaryQuestion(string message);
        string SelectFilePathToSaveExcelFile();
        IList<NewsletterUserViewItem> GetNewsletterUserList();
        DialogResult OpenAddNewsletterUserView();
        DialogResult OpenNewsletterUserViewSelected(NewsletterUserViewItem selected);
        void ShowSuccessMessage(string message);
    }
}
