using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Presenter
{
    public interface INewsletterUserListPresenter : IPresenter
    {
        void OnNewNewsletterUser();
        void OnExportToExcel();
        void OnRemoveNewsletterUser();
    }
}
