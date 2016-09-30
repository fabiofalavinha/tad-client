using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class EventResult
    {
        public Event Target { get; private set; }
        public bool Removed { get; private set; }

        public EventResult(Event target)
            : this(target, false)
        {
        }

        public EventResult(Event target, bool removed)
        {
            Target = target;
            Removed = removed;
        }
    }
}
