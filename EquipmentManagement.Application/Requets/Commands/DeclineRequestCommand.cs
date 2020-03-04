using EquipmentManagement.Infrastructura.Commands;

namespace EquipmentManagement.Application.Requets.Commands
{
    public class DeclineRequestCommand : CommandBase
    {
        public int RequestId { get; }

        public string Message { get; }

        public DeclineRequestCommand(int id, string message)
        {
            RequestId = id;
            Message = message;
        }
    }
}
