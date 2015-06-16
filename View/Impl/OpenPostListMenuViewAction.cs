using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.View.Impl
{
    public class OpenPostListMenuViewAction : IMenuActionView
    {
        public void Open(IMainView mainView)
        {
            mainView.OpenPostListView();
        }
    }
}
