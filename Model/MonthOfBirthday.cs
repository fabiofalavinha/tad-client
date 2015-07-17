using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public class MonthOfBirthday
    {
        public int Month { get; private set; }
        public string Text { get { return new DateTime(DateTime.Now.Year, Month, 1).ToString("MMM"); } }

        public MonthOfBirthday(int month)
        {
            Month = month;
        }

        public bool IsFrom(DateTime dateTime)
        {
            return Month == dateTime.Month;
        }

        public override bool Equals(object obj)
        {
            var other = obj as MonthOfBirthday;
            return other != null && Month == other.Month;
        }

        public override int GetHashCode()
        {
            var hash = 3;
            hash += 17 * Month.GetHashCode();
            return hash;
        }
    }
}
