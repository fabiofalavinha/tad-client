using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IConsecrationHistoryListView : IControlView
    {
        void SetConsecrationList(IList<ConsecrationViewItem> list);
    }
}
