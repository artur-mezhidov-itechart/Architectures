namespace EquipmentManagement.Infrastructura.Events.Contracts
{
    public interface IEventDispatcher
    {
        void Publish<TEvent>() where TEvent : IEvent, new();

        void Publish<TEvent>(TEvent e) where TEvent : IEvent;
    }
}
