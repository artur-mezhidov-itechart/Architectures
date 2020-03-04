using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Infrastructura.Events;

namespace EquipmentManagement.Application.Requets.Events
{
    public class RequestCreatedEvent : EventBase
    {
        public Request CreatedRequest { get; }

        public RequestCreatedEvent(Request request)
        {
            CreatedRequest = request;
        }
    }
}
