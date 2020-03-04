using EquipmentManagement.Infrastructura.Commands;

namespace EquipmentManagement.Application.Requets.Commands
{
    public class CompleteRequestCommand : CommandBase
    {
        public int RequestId { get; }

        public CompleteRequestCommand(int requestId)
        {
            RequestId = requestId;
        }
    }
}
