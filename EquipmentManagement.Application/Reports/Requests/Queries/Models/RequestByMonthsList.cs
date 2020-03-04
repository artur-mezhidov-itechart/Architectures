using System.Collections.Generic;

namespace EquipmentManagement.Application.Reports.Requests.Queries.Models
{
    public class RequestByMonthsList
    {
        public IEnumerable<RequestByMonths> Items { get; set; }
    }
}
