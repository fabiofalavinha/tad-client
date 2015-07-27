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
    public class PostListPresenter : AbstractControlPresenter<IPostListView>, IPostListPresenter
    {
        private readonly PostService postService;

        public PostListPresenter(IPostListView view)
            : base(view)
        {
            this.postService = new PostService();
        }

        public void InitView()
        {
            DoLoadPostsAsync();
        }

        private void DoLoadPostsAsync()
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
                        postService.RemovePost(post.Wrapper);
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
                        postService.SavePost(post);
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
            var posts = postService.FindPosts(UserContext.GetInstance().LoggedUser);
            View.SetPostList(posts.Select(p => new PostViewItem(p)).ToArray());
        }

        public void OnNewPost()
        {
            View.OpenNewPostView();
        }

        private bool postListOrderChanged = false;

        public void OnOrderPost(PostOrderViewItem viewItem)
        {
            if (postListOrderChanged = View.IsPostListOrderOptionChecked())
            {
                var list = View.GetPostList().ToList();
                list.RemoveAt(viewItem.LastPosition);
                list.Insert(viewItem.NewPosition, viewItem.Data);
                var orderIndex = 1;
                foreach (var postViewItem in list)
                {
                    if (postViewItem.IsPublished)
                    {
                        postViewItem.Wrapper.Order = orderIndex++;
                    }
                    else
                    {
                        postViewItem.Wrapper.Order = 0;
                    }
                }
                View.SetPostList(list);
            }
        }

        public void OnEnablePostListOrder()
        {
            var optionChecked = View.IsPostListOrderOptionChecked();
            if (!optionChecked && postListOrderChanged)
            {
                if (!View.ShowBinaryQuestion("Você fez alterações na lista de posts. Deseja perder as alterações?"))
                {
                    return;
                }
                else
                {
                    DoLoadPostsAsync();
                }
            }
            View.SetPostListSaveOrderButtonVisible(optionChecked);
        }

        public void OnSavePostListOrder()
        {
            var task = new Task(() =>
            {
                View.ShowWaitingPanel("Salvando post(s)...");
                var postService = new PostService();
                foreach (var post in View.GetPostList().Select(i => i.Wrapper).ToArray())
                {
                    postService.SavePost(post);
                }
            });
            task.ContinueWith(t =>
            {
                try
                {
                    View.SetOrderListOptionChecked(postListOrderChanged = false);
                    DoLoadPosts();
                }
                catch (Exception ex)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao carregar a nova lista de posts: {0}", ex.Message));
                }
                finally
                {
                    View.HideWaitingPanel();
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao re-publicar os posts [{0}]. Tente repetir a operação. {1}", View.GetPostSelected().Title, innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }


        public void OnPostSelected()
        {
            var postViewItem = View.GetPostSelected();
            View.SetUnPublishButtonVisible(postViewItem.IsPublished);
        }

        public void OnUnPublishPost()
        {
            var task = new Task<bool>(() =>
            {
                var postViewItem = View.GetPostSelected();
                if (postViewItem != null)
                {
                    var post = postViewItem.Wrapper;
                    if (post.IsPublished)
                    {
                        if (View.ShowBinaryQuestion("Deseja despublicar este post?"))
                        {
                            post.Unpublish();
                            var postService = new PostService();
                            postService.SavePost(post);
                            return true;
                        }
                    }
                }
                return false;
            });
            task.ContinueWith(t =>
            {
                try
                {
                    if (t.Result)
                    {
                        View.ShowWaitingPanel("Atualizando a lista de posts...");
                        DoLoadPosts();
                    }
                }
                catch (Exception ex)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao carregar a nova lista de posts: {0}", ex.Message));
                }
                finally
                {
                    View.HideWaitingPanel();
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao salvar os dados do post. Tente repetir a operação. {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }
    }
}
