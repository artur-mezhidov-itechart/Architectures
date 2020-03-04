using EquipmentManagement.Infrastructura.Commands;

namespace EquipmentManagement.Application.Equipments.Commands
{
    public class ReturnEquipmentCommand : CommandBase
    {
        public int RequestId { get; }

        public ReturnEquipmentCommand(int requestId)
        {
            RequestId = requestId;
        }
    }
}
