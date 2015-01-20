using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public class Collaborator
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        public Telephone[] Telephones { get; set; }
    }
}
