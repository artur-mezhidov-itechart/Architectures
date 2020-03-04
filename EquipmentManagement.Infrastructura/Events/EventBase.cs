using System;
using EquipmentManagement.Infrastructura.Events.Contracts;

namespace EquipmentManagement.Infrastructura.Events
{
    public abstract class EventBase : IEvent
    {
        public DateTime CreatedAt { get; }

        protected EventBase()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
