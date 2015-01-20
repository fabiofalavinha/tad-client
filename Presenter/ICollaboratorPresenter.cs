using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.Presenter
{
    public interface ICollaboratorPresenter : IPresenter
    {
        void InitViewWith(Collaborator collaborator);
        void OnBackToListCollaboratorView();
        void OnEnableReleaseDateOption();

        void OnAddTelephone();

        void OnRemoveTelephone();

        void OnSave();
    }
}
