using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter
{
    public interface IPostListPresenter : IPresenter
    {
        void OnRemovePost();
        void OnViewPostDetails();
        void OnPublishPost();
        void OnNewPost();
        void OnOrderPost(PostOrderViewItem viewItem);
        void OnEnablePostListOrder();
        void OnSavePostListOrder();
        void OnPostSelected();
        void OnUnPublishPost();
    }
}
