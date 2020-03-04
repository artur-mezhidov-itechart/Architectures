using EquipmentManagement.Application.Requets.Commands;
using EquipmentManagement.Domain;
using EquipmentManagement.Infrastructura.Commands.Contracts;
using EquipmentManagement.Infrastructura.Events;

namespace EquipmentManagement.Application.Requets.Events.Handlers
{
    public class RequestCreatedEventHandler : EventHandlerBase<RequestCreatedEvent>
    {
        private readonly ICommandDispatcher commandDispatcher;

        public RequestCreatedEventHandler(ICommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        protected override void OnHandling(RequestCreatedEvent e)
        {
            commandDispatcher.Execute(new UpdateRequestStatusCommand(e.CreatedRequest.Id, RequestStatus.Pending));
        }
    }
}
