using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Presenter
{
    public interface IListPostPresenter : IPresenter
    {
        void OnRemovePost();

        void OnViewPostDetails();

        void OnPublishPost();

        void OnNewPost();
    }
}
