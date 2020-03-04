using EquipmentManagement.Domain;
using EquipmentManagement.Infrastructura.Commands;

namespace EquipmentManagement.Application.Requets.Commands
{
    public class CreateRequestCommand : CommandBase
    {
        public string Message { get; }

        public EquipmentType EquipmentType { get; }

        public CreateRequestCommand(string message, EquipmentType equipmentType)
        {
            Message = message;
            EquipmentType = equipmentType;
        }
    }
}
