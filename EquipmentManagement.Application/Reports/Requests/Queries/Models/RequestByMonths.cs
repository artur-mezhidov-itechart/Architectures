using System.Collections.Generic;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.Reports.Requests.Queries.Models
{
    public class RequestByMonths
    {
        public EquipmentType Type { get; set; }

        public IEnumerable<RequestCountByMonth> Counts { get; set; }
    }
}
