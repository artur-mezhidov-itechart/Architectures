using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.Reports.Requests.Queries.Models
{
    public class RequestByStatusValue
    {
        public RequestStatus Status { get; set; }

        public double Percent { get; set; }

        public int Count { get; set; }
    }
}
