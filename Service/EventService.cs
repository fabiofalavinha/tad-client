using System;
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

        public Consecration FindConsecrationByEventId(string id)
        {
            return restTemplate.GetForObject<Consecration>("/event/{id}/consecration", id);
        }

        public IList<Consecration> FindAllConsecrations()
        {
            return restTemplate.GetForObject<IList<Consecration>>("/event/consecrations");
        }
    }
}
