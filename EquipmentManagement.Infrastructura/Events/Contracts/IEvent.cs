using System;

namespace EquipmentManagement.Infrastructura.Events.Contracts
{
    public interface IEvent
    {
        DateTime CreatedAt { get; }
    }
}
