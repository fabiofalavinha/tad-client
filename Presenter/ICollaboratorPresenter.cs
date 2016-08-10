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
        void OnEnableStartDateOption();
        void OnUserRoleChanged();
        void OnObservationChanged();
    }
}
