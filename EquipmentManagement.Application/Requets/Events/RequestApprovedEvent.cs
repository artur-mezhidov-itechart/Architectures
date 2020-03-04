using System;
using EquipmentManagement.Infrastructura.Events;

namespace EquipmentManagement.Application.Requets.Events
{
    public class RequestApprovedEvent : EventBase
    {
        public int RequestId { get; set; }

        public int EquipmentId { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
