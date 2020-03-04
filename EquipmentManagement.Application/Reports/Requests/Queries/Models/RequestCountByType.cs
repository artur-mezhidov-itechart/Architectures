using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.Reports.Requests.Queries.Models
{
    public class RequestCountByType
    {
        public int Count { get; set; }

        public double Percent { get; set; }

        public EquipmentType Type { get; set; }
    }
}
