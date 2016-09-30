using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter
{
    public interface INewsletterUserPresenter : IPresenter
    {
        void OnSave();
        void OnCancel();
    }
}
