using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public class Event
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public VisibilityType Visibility { get; set; }
    }
}
