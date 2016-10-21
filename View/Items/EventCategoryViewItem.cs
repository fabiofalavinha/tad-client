using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class EventCategoryViewItem
    {
        public EventCategory Wrapper { get; private set; }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public EventCategoryViewItem(EventCategory wrapper)
        {
            Wrapper = wrapper;
            Id = (int)wrapper;
            Name = wrapper.Translate();
        }
    }
}
