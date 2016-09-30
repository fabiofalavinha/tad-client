namespace TadManagementTool.Model
{
    public static class GenderTypeExtensions
    {
        public static string Translate(this GenderType genderType)
        {
            switch (genderType)
            {
                case GenderType.Male: return "Masculino";
                case GenderType.Female: return "Feminino";
                default: return "Não Informado";
            }
        }
    }

    public enum GenderType
    {
        Male = 0,
        Female = 1
    }
}
