using System;
using System.Collections.Generic;

namespace TadManagementTool.Model
{
    public enum EventCategory
    {
        General = 0,
        Consecration = 1
    }

    public static class EventCategoryExtensions
    {
        public static EventCategory FromValue(this int value)
        {
            return (EventCategory)Enum.ToObject(typeof(EventCategory), value);
        }

        public static string Translate(this EventCategory eventCategory)
        {
            switch (eventCategory)
            {
                case EventCategory.General: return "Normal";
                case EventCategory.Consecration: return "Consagração";
                default: throw new ArgumentException(nameof(eventCategory));
            }
        }

        public static IList<EventCategory> GetEventCategoryList()
        {
            return new[] { EventCategory.General, EventCategory.Consecration };
        }
    }
}
