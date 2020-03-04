using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.Reports.Equipments.Queries.Models
{
    public class RatioOfEquipment
    {
        public EquipmentType Type { get; set; }

        public double PercentValue { get; set; }

        public double Value { get; set; }
    }
}
