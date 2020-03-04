using System;

namespace EquipmentManagement.Domain.Entities
{
    public class History : EntityBase
    {
        public ActionType Type { get; set; }

        public DateTime ActionDate { get; set; }

        public string Info { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
