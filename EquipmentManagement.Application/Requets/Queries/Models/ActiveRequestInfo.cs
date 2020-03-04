using System;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.Requets.Queries.Models
{
    public class ActiveRequestInfo
    {
        public int RequestId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string AssignedUserId { get; set; }

        public string AssignedUserEmail { get; set; }

        public string AssignedUserName { get; set; }

        public string RequestMessage { get; set; }

        public string StatusMessage { get; set; }

        public string CreatedOn { get; set; }

        public string UpdatedOn { get; set; }

        public EquipmentType EquipmentType { get; set; }

        public RequestStatus CurrentStatus { get; set; }
    }
}
