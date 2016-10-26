using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class ConsecrationEnrollmentPresenter : AbstractDialogPresenter<IConsecrationEnrollmentView>, IConsecrationEnrollmentPresenter 
    {
        private readonly EventService eventService;

        public ConsecrationEnrollmentPresenter(IConsecrationEnrollmentView view)
            : base(view)
        {
            eventService = new EventService();
        }

        public void InitView()
        {
            
        }
    }
}
