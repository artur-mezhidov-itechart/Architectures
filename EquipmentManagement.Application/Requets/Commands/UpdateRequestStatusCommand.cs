using EquipmentManagement.Domain;
using EquipmentManagement.Infrastructura.Commands;

namespace EquipmentManagement.Application.Requets.Commands
{
    public class UpdateRequestStatusCommand : CommandBase
    {
        public int RequestId { get; }
        
        public RequestStatus Status { get; }

        public string Message { get; set; }

        public UpdateRequestStatusCommand(int requestId, RequestStatus status)
        {
            RequestId = requestId;
            Status = status;
        }
    }
}
