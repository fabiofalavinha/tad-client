using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class NewsletterUserPresenter : AbstractControlPresenter<INewsletterUserView>, INewsletterUserPresenter
    {
        public NewsletterUserPresenter(INewsletterUserView view)
            : base(view)
        {
        }
    }
}
