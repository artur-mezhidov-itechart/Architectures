using System;
using EquipmentManagement.Infrastructura.Events.Contracts;

namespace EquipmentManagement.Infrastructura.Events.Exceptions
{
    public abstract class EventExceptionBase : Exception
    {
        public IEvent Event { get; }

        protected EventExceptionBase(IEvent e) : this(e, null)
        {
        }

        protected EventExceptionBase(IEvent e, Exception innerException) : base(innerException.Message, innerException)
        {
            Event = e;
        }
    }
}
