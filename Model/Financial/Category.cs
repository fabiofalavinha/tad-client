using System;

namespace TadManagementTool.Model.Financial
{
    public static class CategoryExtensions
    {
        public static string Translate(this Category category)
        {
            switch (category)
            {
                case Category.Receivable: return "Entrada";
                case Category.Payable: return "Saída";
                default: return "N/A";
            }
        }

        public static Category FromValue(int value)
        {
            return (Category)Enum.ToObject(typeof(Category), value);
        }

        public static string TranslateValue(int value)
        {
            switch (value)
            {
                case (int)Category.Receivable: return "C";
                case (int)Category.Payable: return "D";
                default: return "N/A";
            }
        }
    }
    public enum Category
    {
        Receivable = 1,
        Payable = 2
    }
}


