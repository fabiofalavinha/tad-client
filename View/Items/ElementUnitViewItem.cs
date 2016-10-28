using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class ElementUnitViewItem
    {
        public ElementUnit Wrapper { get; private set; }

        public int Id { get { return (int)Wrapper; } }
        public string Name { get { return Wrapper.Translate(); } }

        public ElementUnitViewItem(ElementUnit unit)
        {
            Wrapper = unit;
        }
    }
}
