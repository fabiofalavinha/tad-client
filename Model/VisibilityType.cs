using System;

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

        public static VisibilityType FromValue(int value)
        {
            return (VisibilityType)Enum.ToObject(typeof(VisibilityType), value);
        }
    }

    public enum VisibilityType
    {
        Internal = 0,
        Public = 1
    }
}
