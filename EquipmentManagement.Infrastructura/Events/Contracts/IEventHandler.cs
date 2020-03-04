namespace EquipmentManagement.Infrastructura.Events.Contracts
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        void Handle(TEvent e);
    }
}
