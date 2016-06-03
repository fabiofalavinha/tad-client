using TadManagementTool.Model.Financial;

namespace TadManagementTool.View.Items
{
    public class FinancialEntryViewItem
    {
        public static FinancialEntryViewItem NewEntry()
        {
            var entry = new FinancialEntry();
            return new FinancialEntryViewItem()
            {
                Id = entry.Id,
                Date = entry.Date.ToShortDateString()
            };
        }

        public string Id { get; set; }
        public string Date { get; set; }
    }
}
