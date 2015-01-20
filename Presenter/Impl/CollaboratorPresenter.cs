using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;
using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class CollaboratorPresenter : AbstractControlPresenter<ICollaboratorView>, ICollaboratorPresenter
    {
        public CollaboratorPresenter(ICollaboratorView view)
            : base(view)
        {
        }

        public void InitView()
        {
        }

        public void InitViewWith(Collaborator collaborator)
        {
            throw new NotImplementedException();
        }

        public void OnBackToListCollaboratorView()
        {
            View.OpenListCollaboratorView();
        }
    }
}
