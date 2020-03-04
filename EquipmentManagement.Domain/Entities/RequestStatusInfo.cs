using System;

namespace EquipmentManagement.Domain.Entities
{
    public class RequestStatusInfo : EntityBase
    {
        public RequestStatus Status { get; set; }

        public string Message { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public int RequestId { get; set; }

        public Request Request { get; set; }
    }
}
