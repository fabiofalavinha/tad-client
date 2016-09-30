using TadManagementTool.Model.Financial;

namespace TadManagementTool.View.Items
{
    public class CategoryViewItem
    {
        public Category Wrapper { get; private set; }

        public CategoryViewItem(Category wrapper)
        {
            Wrapper = wrapper;
        }

        public override string ToString()
        {
            return Wrapper.Translate();
        }
    }
}
