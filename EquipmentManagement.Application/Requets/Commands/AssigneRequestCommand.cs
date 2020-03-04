using EquipmentManagement.Infrastructura.Commands;

namespace EquipmentManagement.Application.Requets.Commands
{
    public class AssigneRequestCommand : CommandBase
    {
        public int RequestId { get; }

        public AssigneRequestCommand(int requestId)
        {
            RequestId = requestId;
        }
    }
}
