using EquipmentManagement.Domain;
using EquipmentManagement.Infrastructura.Commands;

namespace EquipmentManagement.Application.Equipments.Commands
{
    public class AddEquipmentCommand : CommandBase
    {
        public string Name { get; }

        public double Price { get; }

        public EquipmentType Type { get; }

        public AddEquipmentCommand(string name, double price, EquipmentType type)
        {
            Name = name;
            Price = price;
            Type = type;
        }
    }
}
