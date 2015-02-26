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
    }
}
