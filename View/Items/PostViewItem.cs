using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class PostViewItem
    {
        public Post Wrapper { get; private set; }

        public string Title { get { return Wrapper.Title; } }
        public string Created { get { return Wrapper.Created.ToString(); } }
        public string CreatedBy { get { return Wrapper.CreatedBy.Name; } }
        public string Modified { get { return Wrapper.Modified.ToString(); } }
        public string ModifiedBy { get { return Wrapper.ModifiedBy.Name; } }
        public string Visibility { get { return Wrapper.Visibility.Translate(); } }
        public bool IsPublished { get { return Wrapper.IsPublished; } }
        public string Published { get { return Wrapper.Published.HasValue ? Wrapper.Published.Value.ToString() : "N/A"; } }
        public string PublishedBy { get { return Wrapper.PublishedBy != null ? Wrapper.PublishedBy.Name : "N/A"; } }

        public PostViewItem(Post wrapper)
        {
            Wrapper = wrapper;
        }
    }
}
