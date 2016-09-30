namespace TadManagementTool.Model
{
    public enum PhoneType
    {
        Home = 0,
        Work = 1,
        Mobile = 2
    }

    public static class PhoneTypeExtensions
    {
        public static string Translate(this PhoneType phoneType)
        {
            switch (phoneType)
            {
                case PhoneType.Home: return "Residencial";
                case PhoneType.Mobile: return "Celular";
                case PhoneType.Work: return "Trabalho";
                default: return phoneType.ToString();
            }
        }
    }
}
