﻿using System.Globalization;
using TadManagementTool.Model.Financial;

namespace TadManagementTool.View.Items
{
    public class FinancialEntryViewItem
    {
        public static FinancialEntryViewItem NewEntry()
        {
            var entry = new FinancialEntry();
            return new FinancialEntryViewItem(entry)
            {
                Id = entry.Id,
                Date = entry.ToEntryDate().ToShortDateString()
            };
        }

        public static FinancialEntryViewItem FromModel(FinancialEntry wrapper)
        {
            return new FinancialEntryViewItem(wrapper)
            {
                Id = wrapper.Id,
                Date = wrapper.ToEntryDate().ToString("dd/MM/yyyy"),
                TargetReference = wrapper.Target.Id,
                TargetDescription = wrapper.Target.Name,
                TypeReference = wrapper.Type.Id,
                TypeReferenceName = wrapper.Type.Description,
                Category = CategoryExtensions.TranslateValue(wrapper.Type.Category),
                AdditionalText = wrapper.AdditionalText,
                Value = wrapper.Value.ToString("#,#0.00#;(#,#0.00#)", new CultureInfo("pt-BR")),
                Balance = wrapper.Balance.Value.ToString("#,#0.00#;(#,#0.00#)", new CultureInfo("pt-BR")),
                Receipt = wrapper.FinancialReceiptInfo == null || string.IsNullOrWhiteSpace(wrapper.FinancialReceiptInfo.Number) ? "N/D" : string.Concat(wrapper.FinancialReceiptInfo.Number, " - ", wrapper.FinancialReceiptInfo.Sent)
            };
        }

        public FinancialEntry Wrapper { get; private set; }

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
        public string Receipt { get; set; }

        public FinancialEntryViewItem(FinancialEntry wrapper)
        {
            Wrapper = wrapper;
        }
    }
}
