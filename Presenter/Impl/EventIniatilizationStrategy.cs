using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;
using TadManagementTool.Service;

namespace TadManagementTool.Presenter.Impl
{
    public class EventIniatilizationStrategy : IConsecrationInitializationStrategy
    {
        private readonly Event currentEvent;

        public EventIniatilizationStrategy(Event currentEvent)
        {
            this.currentEvent = currentEvent;
        }

        public Consecration GetConsecration()
        {
            var service = new EventService();
            var consecration = service.FindConsecrationByEventId(currentEvent.Id);
            return consecration == null
                ? new Consecration() { Event = currentEvent }
                : consecration;
        }
    }
}
