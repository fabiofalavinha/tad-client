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
            var task = new Task(() =>
            {
                View.ShowWaitingPanel("Carregando posts...");
                DoLoadPosts();
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao carregar os posts. Tente repetir a operação. {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnRemovePost()
        {
            var task = new Task<bool>(() =>
            {
                var post = View.GetPostSelected();
                if (post != null)
                {
                    if (View.ShowBinaryQuestion("Deseja apagar este post?"))
                    {
                        View.ShowWaitingPanel("Removendo post...");
                        postService.removePost(post.Wrapper);
                        return true;
                    }
                }
                return false;
            });
            task.ContinueWith(t =>
            {
                if (t.Result)
                {
                    View.ShowWaitingPanel("Carregando posts...");
                    DoLoadPosts();
                }
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao apagar o post [{0}]. Tente repetir a operação. {1}", View.GetPostSelected().Title, innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
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
            var task = new Task<bool>(() =>
            {
                var postViewItem = View.GetPostSelected();
                if (postViewItem != null)
                {
                    if (View.ShowBinaryQuestion("Deseja publicar este post?"))
                    {
                        View.ShowWaitingPanel("Publicando post...");
                        var post = postViewItem.Wrapper;
                        post.Published = DateTime.Now;
                        post.PublishedBy = UserContext.GetInstance().LoggedUser;
                        postService.savePost(post);
                        return true;
                    }
                }
                return false;
            });
            task.ContinueWith(t =>
            {
                if (t.Result)
                {
                    View.ShowWaitingPanel("Carregando posts...");
                    DoLoadPosts();
                }
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao publicar o post [{0}]. Tente repetir a operação. {1}", View.GetPostSelected().Title, innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        private void DoLoadPosts()
        {
            var posts = postService.findPosts(UserContext.GetInstance().LoggedUser);
            View.SetPostList(posts.Select(p => new PostViewItem(p)).ToArray());
        }

        public void OnNewPost()
        {
            View.OpenNewPostView();
        }
    }
}
