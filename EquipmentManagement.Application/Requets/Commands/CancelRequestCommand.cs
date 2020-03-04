using EquipmentManagement.Infrastructura.Commands;

namespace EquipmentManagement.Application.Requets.Commands
{
    public class CancelRequestCommand : CommandBase
    {
        public int RequestId { get; }

        public string Message { get; }

        public CancelRequestCommand(int id, string message)
        {
            RequestId = id;
            Message = message;
        }
    }
}
