using EquipmentManagement.Infrastructura.Events;

namespace EquipmentManagement.Application.Requets.Events
{
    public class RequestAssignedEvent : EventBase
    {
        public int RequestId { get; }

        public RequestAssignedEvent(int requestId)
        {
            RequestId = requestId;
        }
    }
}
