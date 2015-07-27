using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }

    public enum Category
    {
        Receivable = 1,
        Payable = 2
    }
}
