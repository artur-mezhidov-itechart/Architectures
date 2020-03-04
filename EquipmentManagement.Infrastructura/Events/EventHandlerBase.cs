using System;
using EquipmentManagement.Infrastructura.Events.Contracts;
using EquipmentManagement.Infrastructura.Events.Exceptions;

namespace EquipmentManagement.Infrastructura.Events
{
    public abstract class EventHandlerBase<TEvent> : IEventHandler<TEvent> where TEvent : IEvent
    {
        protected abstract void OnHandling(TEvent e);

        public void Handle(TEvent e)
        {
            try
            {
                OnHandling(e);
            }
            catch (Exception exception)
            {
                throw new EventOnHandlingException(e, GetType(), exception);
            }
        }
    }
}
