using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.Service
{
    public class EventService : AbstractService
    {
        public IList<Event> FindEventByYear(int year)
        {
            return restTemplate.GetForObject<IList<Event>>("/events/{year}", year);
        }

        public void AddEvent(Event newEvent)
        {
            restTemplate.PostForMessage<Event>("/event", newEvent);
        }

        public void RemoveEventById(string id)
        {
            restTemplate.Delete("/event/{id}", id);
        }
    }
}
