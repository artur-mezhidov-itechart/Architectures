using System.Collections.Generic;

namespace EquipmentManagement.Application.Reports.Requests.Queries.Models
{
    public class RequestByStatus
    {
        public int Year { get; set; }

        public List<RequestByStatusValue> Values { get; set; }
    }
}
