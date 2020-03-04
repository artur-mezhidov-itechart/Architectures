using System.Collections.Generic;

namespace EquipmentManagement.Application.Reports.Equipments.Queries.Models
{
    public class RatioOfEquipments
    {
        public double Total { get; set; }

        public IEnumerable<RatioOfEquipment> Items { get; set; }
    }
}
