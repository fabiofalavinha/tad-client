using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.View.Impl
{
    public class OpenCollaboratorBirthDaysMenuViewAction : IMenuActionView
    {
        public void Open(IMainView mainView)
        {
            mainView.OpenCollaboratorBirthDaysView();
        }
    }
}
