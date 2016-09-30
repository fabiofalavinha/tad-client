using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        void ShowSuccessMessage(string message);
    }
}
