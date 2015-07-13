using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public static class VisibilityTypeExtensions
    {
        public static string Translate(this VisibilityType visibilityType)
        {
            switch (visibilityType)
            {
                case VisibilityType.Internal: return "Interno";
                case VisibilityType.Public: return "Público";
                default: return "N/A";
            }
        }
    }

    public enum VisibilityType
    {
        Internal = 0,
        Public = 1
    }
}
