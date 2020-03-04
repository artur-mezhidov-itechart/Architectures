using System;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.Requets.Queries.Models
{
    public class RequestStatusDetails
    {
        public int Id { get; set; }

        public string UpdatedUserId { get; set; }

        public string UpdatedUserEmail { get; set; }

        public string UpdatedUserName { get; set; }

        public DateTime UpdatedAt { get; set; }

        public RequestStatus Status { get; set; }

        public string Message { get; set; }
    }
}
