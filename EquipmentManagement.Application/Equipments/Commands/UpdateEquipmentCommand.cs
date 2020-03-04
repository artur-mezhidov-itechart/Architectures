using EquipmentManagement.Domain;
using EquipmentManagement.Infrastructura.Commands;

namespace EquipmentManagement.Application.Equipments.Commands
{
    public class UpdateEquipmentCommand : CommandBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public EquipmentType Type { get; set; }

        public UpdateEquipmentCommand(int id, string name, double price, EquipmentType type)
        {
            Id = id;
            Name = name;
            Price = price;
            Type = type;
        }
    }
}
