using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter
{
    public class ConsecrationHistoryListPresenter : AbstractControlPresenter<IConsecrationHistoryListView>, IConsecrationHistoryListPresenter
    {
        private readonly EventService eventService;

        public ConsecrationHistoryListPresenter(IConsecrationHistoryListView view)
            : base(view)
        {
            eventService = new EventService();
        }

        public void InitView()
        {
            throw new NotImplementedException();
        }
    }
}
