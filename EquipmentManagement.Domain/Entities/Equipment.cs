using System.Collections.Generic;

namespace EquipmentManagement.Domain.Entities
{
    public class Equipment : EntityBase
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public EquipmentType Type { get; set; }

        public List<UserEquipment> UserEquipments { get; set; }
    }
}
