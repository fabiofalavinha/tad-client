﻿using System.Linq;
using TadManagementTool.Extensions;
using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class CollaboratorViewItem
    {
        public Collaborator Wrapper { get; private set; }
        public string Name { get { return Wrapper.Name; } }
        public string Email { get { return Wrapper.Email; } }
        public string BirthDate { get { return Wrapper.BirthDate.ToString("dd/MMM/yyyy"); } }
        public string StartDate { get { return Wrapper.StartDate.HasValue ? Wrapper.StartDate.Value.ToString("dd/MMM/yy") : "N/A"; } }
        public string GenderType { get { return Wrapper.Gender.TransalateGenderType(); } }
        public string Telephones { get { return string.Join(", ", Wrapper.Telephones.Select(t => string.Format("{0}: ({1}) {2}", t.PhoneType.Translate(), t.AreaCode, t.Number))); } }
        public string Active { get { return Wrapper.Active ? "Sim" : "Não"; } }
        public string Observation { get { return Wrapper.Observation; } }
        public string IsContributor { get { return Wrapper.Contributor ? "Sim" : "Não"; } }

        public CollaboratorViewItem(Collaborator collaborator)
        {
            Wrapper = collaborator;
        }
    }
}
