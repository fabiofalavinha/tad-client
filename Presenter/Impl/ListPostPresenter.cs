using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class ListPostPresenter : AbstractControlPresenter<IListPostView>, IListPostPresenter
    {
        private readonly PostService postService;

        public ListPostPresenter(IListPostView view)
            : base(view)
        {
            this.postService = new PostService();
        }

        public void InitView()
        {
            var task = new Task<IList<Post>>(() =>
            {
                View.ShowWaitingPanel("Carregando posts...");
                return postService.findPosts(UserContext.GetInstance().LoggedUser);
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                View.SetPostList(t.Result.Select(p => new PostViewItem(p)).ToArray());
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao carregar os posts. Tente repitir a operação. {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnRemovePost()
        {
        }

        public void OnViewPostDetails()
        {
            var postViewItem = View.GetPostSelected();
            if (postViewItem != null)
            {
                View.OpenEditPostView(postViewItem.Wrapper);
            }
        }

        public void OnPublishPost()
        {
        }

        public void OnNewPost()
        {
            View.OpenNewPostView();
        }
    }
}
