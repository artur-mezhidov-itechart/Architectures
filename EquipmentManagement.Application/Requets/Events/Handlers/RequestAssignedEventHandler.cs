using EquipmentManagement.Application.Requets.Commands;
using EquipmentManagement.Domain;
using EquipmentManagement.Infrastructura.Commands.Contracts;
using EquipmentManagement.Infrastructura.Events;

namespace EquipmentManagement.Application.Requets.Events.Handlers
{
    public class RequestAssignedEventHandler : EventHandlerBase<RequestAssignedEvent>
    {
        private readonly ICommandDispatcher commandDispatcher;

        public RequestAssignedEventHandler(ICommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        protected override void OnHandling(RequestAssignedEvent e)
        {
            commandDispatcher.Execute(new UpdateRequestStatusCommand(e.RequestId, RequestStatus.InProgress));
        }
    }
}
