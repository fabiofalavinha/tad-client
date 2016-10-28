using System;

namespace TadManagementTool.Model
{
    public static class ElementUnitExtensions
    {
        public static string Translate(this ElementUnit unit)
        {
            switch (unit)
            {
                case ElementUnit.None: return "Outro(s)";
                case ElementUnit.Sack: return "Saco(s)";
                case ElementUnit.Box: return "Caixa(s)";
                case ElementUnit.Kg: return "Kg";
                case ElementUnit.Pack: return "Pacote(s)";
                case ElementUnit.Pot: return "Pote(s)";
                default: throw new ArgumentException(nameof(unit));
            }
        }
    }
}
