using System;

namespace EquipmentManagement.Application.Reports.Requests.Queries.Models
{
    public class RequestCountByMonth
    {
        public DateTime Date { get; set; }

        public int Count { get; set; }
    }
}
