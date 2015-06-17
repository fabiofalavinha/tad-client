using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;
using TadManagementTool.View.Items;

namespace TadManagementTool.View.Impl
{
    public interface IListPostView : IControlView
    {
        PostViewItem GetPostSelected();
        void SetPostList(IList<PostViewItem> list);
        void OpenNewPostView();
        void OpenEditPostView(Post post);
    }
}
