using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Presenter
{
    public interface INewsletterUserListPresenter : IPresenter
    {
        void OnAddNewsletterUser();
        void OnExportToExcel();
        void OnRemoveNewsletterUser();
    }
}
