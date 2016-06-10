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

        public static FinancialEntryViewItem FromModel(FinancialEntry wrapper)
        {
            return new FinancialEntryViewItem()
            {
                Id = wrapper.Id,
                Date = wrapper.Date.ToShortDateString(),
                TargetReference = wrapper.Target.Reference,
                TargetDescription = wrapper.Target.Description,
                TypeReference = wrapper.Type.Id,
                TypeReferenceName = wrapper.Type.Description,
                Category = CategoryExtensions.TranslateValue(wrapper.Type.Category),
                AdditionalText = wrapper.AdditionalText,
                Value = wrapper.Value.ToString(),
                Balance = wrapper.Balance.ToString()
            };
        }

        public string Id { get; set; }
        public string Date { get; set; }
        public string TargetReference { get; set; }
        public string TargetDescription { get; set; }
        public string TypeReference { get; set; }
        public string TypeReferenceName { get; set; }
        public string Category { get; set; }
        public string AdditionalText { get; set; }
        public string Value { get; set; }
        public string Balance { get; set; }
    }
}
