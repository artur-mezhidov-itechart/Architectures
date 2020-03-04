using System;
using Microsoft.Extensions.DependencyInjection;
using EquipmentManagement.Infrastructura.Events.Contracts;
using EquipmentManagement.Infrastructura.Events.Exceptions;

namespace EquipmentManagement.Infrastructura.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public EventDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Publish<TEvent>() where TEvent : IEvent, new()
        {
            Publish(new TEvent());
        }

        public void Publish<TEvent>(TEvent e) where TEvent : IEvent
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            IEventHandler<TEvent> handler;

            try
            {
                handler = serviceProvider.GetRequiredService<IEventHandler<TEvent>>();
            }
            catch (Exception exception)
            {
                throw new EventHandlerNotFoundException(e, typeof(IEventHandler<TEvent>), exception);
            }

            try
            {
                handler.Handle(e);
            }
            catch (EventOnHandlingException exception)
            {
                // TODO: Logging
                throw exception;
            }
        }
    }
}
