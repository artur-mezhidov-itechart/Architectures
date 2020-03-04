using System;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.Requets.Queries.Models
{
    public class RequestInfo
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public EquipmentType EquipmentType { get; set; }

        public DateTime UpdatedOn { get; set; }

        public RequestStatus Status { get; set; }
    }
}
