using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TadManagementTool.View
{
    public interface IDialogView : IView
    {
        void SetDialogResult(DialogResult dialogResult);
        void CloseView();
    }
}
