using System.Collections.Generic;
using TadManagementTool.Model;

namespace TadManagementTool.Service
{
    public class EventService : AbstractService
    {
        public IList<Event> FindEventByYear(int year)
        {
            return restTemplate.GetForObject<IList<Event>>("/events/{year}", year);
        }

        public Event AddEvent(Event newEvent)
        {
            return restTemplate.PostForMessage<Event>("/event", newEvent).Body;
        }

        public void RemoveEventById(string id)
        {
            restTemplate.Delete("/event/{id}", id);
        }
    }
}
