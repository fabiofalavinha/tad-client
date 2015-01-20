using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Presenter
{
    public interface IListCollaboratorPresenter : IPresenter
    {
        void OnRemoveCollaborator();
        void OnNewCollaborator();
        void OnViewCollaboratorDetails();
    }
}
