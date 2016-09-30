using TadManagementTool.Model;

namespace TadManagementTool.Extensions
{
    public static class EnumExtensions
    {
        public static string TransalateGenderType(this GenderType genderType)
        {
            switch (genderType)
            {
                case GenderType.Male: return "Masculino";
                case GenderType.Female: return "Feminino";
                default: return "N/A";
            }
        }
    }
}
