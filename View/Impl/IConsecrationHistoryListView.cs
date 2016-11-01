using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Presenter;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IConsecrationHistoryListView : IControlView
    {
        void SetConsecrationList(IList<ConsecrationViewItem> list);
        DialogResult OpenConsecrationHistoryDetails(IConsecrationInitializationStrategy strategy);
        ConsecrationViewItem GetConsecrationSelected();
    }
}
