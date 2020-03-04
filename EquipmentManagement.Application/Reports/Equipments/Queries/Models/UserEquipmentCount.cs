using System.Collections.Generic;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.Reports.Equipments.Queries.Models
{
    public class UserEquipmentCount
    {
        public int TotalCount { get; set; }

        public EquipmentType Type { get; set; }

        public IEnumerable<UserEquipmentCountItem> Items { get; set; }
    }
}
