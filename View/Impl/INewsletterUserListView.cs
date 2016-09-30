using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        void ShowSuccessMessage(string message);
    }
}
