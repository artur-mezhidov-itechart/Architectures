using System.Collections.Generic;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.Requets.Queries.Models
{
    public class RequestStatusHistory
    {
        public RequestStatus CurrentStatus { get; set; }

        public IEnumerable<RequestStatusDetails> Statuses { get; set; }
    }
}
