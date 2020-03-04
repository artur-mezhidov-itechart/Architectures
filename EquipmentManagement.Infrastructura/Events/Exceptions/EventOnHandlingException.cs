using System;
using EquipmentManagement.Infrastructura.Events.Contracts;

namespace EquipmentManagement.Infrastructura.Events.Exceptions
{
    public class EventOnHandlingException : EventExceptionBase
    {
        public Type EventHandlerType { get; }

        public EventOnHandlingException(IEvent e, Type eventHandlerType, Exception innerException) : base(e, innerException)
        {
            EventHandlerType = eventHandlerType;
        }
    }
}
