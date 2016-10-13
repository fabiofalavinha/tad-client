using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model.Financial
{
    public class Period
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public Period()
        {
            From = new DateTime(DateTime.Now.Year, 1, 1);
            To = DateTime.Now;
        }
    }
}
