using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class ElementViewItem
    {
        public Element Wrapper { get; private set; }
        public string Name { get { return Wrapper.Name; } set { Wrapper.Name = value; } }
        public string Quantity
        {
            get
            {
                return Wrapper.Quantity.ToString();
            }
            set
            {
                int quantity;
                if (!int.TryParse(value, out quantity))
                {
                    throw new ArgumentException("A quantidade deve ser um valor numérico");
                }
                Wrapper.Quantity = quantity;
            }
        }
        public string Unit { get { return Wrapper.Unit; } set { Wrapper.Unit = value; } }
        public string PrimaryCollaboratorId { get { return Wrapper.PrimaryCollaborator.Id; } set { Wrapper.PrimaryCollaborator.Id = value; } }
        public string SecondaryCollaboratorId { get { return Wrapper.SecondaryCollaborator.Id; } set { Wrapper.SecondaryCollaborator.Id = value; } }

        public ElementViewItem(Element element)
        {
            Wrapper = element;
        }
    }
}
