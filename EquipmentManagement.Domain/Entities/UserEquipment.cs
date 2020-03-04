using System;

namespace EquipmentManagement.Domain.Entities
{
    public class UserEquipment : EntityBase
    {
        public DateTime ReceivedDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsReturned { get; set; }

        public string UserId { get; set; }

        public int EquipmentId { get; set; }

        public int RequestId { get; set; }

        public ApplicationUser User { get; set; }

        public Equipment Equipment { get; set; }

        public Request Request { get; set; }
    }
}
