using System;
using EquipmentManagement.Infrastructura.Events.Contracts;

namespace EquipmentManagement.Infrastructura.Events.Exceptions
{
    public class EventHandlerNotFoundException : EventExceptionBase
    {
        public Type EventHandlerType { get; }

        public EventHandlerNotFoundException(IEvent e, Type eventHandlerType, Exception innerException) : base(e, innerException)
        {
            EventHandlerType = eventHandlerType;
        }
    }
}
