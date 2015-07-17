using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IPostListView : IControlView
    {
        PostViewItem GetPostSelected();
        bool ShowBinaryQuestion(string message);
        bool IsPostListOrderOptionChecked();
        IList<PostViewItem> GetPostList();
        void SetPostList(IList<PostViewItem> list);
        void OpenNewPostView();
        void OpenEditPostView(Post post);
        void SetPostListSaveOrderButtonVisible(bool visible);
        void SetOrderListOptionChecked(bool value);
        void SetUnPublishButtonVisible(bool visible);
    }
}
