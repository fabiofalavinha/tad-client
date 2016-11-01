using System.Globalization;
using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class ConsecrationViewItem
    {
        public Consecration Wrapper { get; private set; }
        public string Name { get { return Wrapper.Event.Title; } }
        public string Date { get { return Wrapper.Event.Date.ToString("dd/MMM/yy", new CultureInfo("pt-BR")); } }

        public ConsecrationViewItem(Consecration wrapper)
        {
            Wrapper = wrapper;
        }
    }
}
