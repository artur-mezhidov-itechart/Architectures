using System;
using System.Collections.Generic;

namespace EquipmentManagement.Domain.Entities
{
    public class Request : EntityBase
    {
        public EquipmentType EquipmentType { get; set; }

        public string Message { get; set; }

        public string UserId { get; set; }

        public string AssignedUserId { get; set; }

        public DateTime RequestedOn { get; set; }

        public ApplicationUser User { get; set; }

        public UserEquipment UserEquipment { get; set; }

        public ICollection<RequestStatusInfo> RequestStatusInfos { get; set; }
    }
}
