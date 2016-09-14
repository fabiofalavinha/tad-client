using Newtonsoft.Json;
using System;
using System.Globalization;

namespace TadManagementTool.Model.Financial
{
    public class CloseableFinancialEntry
    {
        [JsonProperty("closedDate")]
        public string ClosedDate { get; set; }

        [JsonProperty("closedBy")]
        public User ClosedBy { get; set; }

        public DateTime ParseCloseDate()
        {
            return DateTime.ParseExact(ClosedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public DateTime AddDay(int day)
        {
            if (day < 0)
            {
                throw new ArgumentException("Invalid day");
            }
            return ParseCloseDate().AddDays(day);
        }
    }
}
