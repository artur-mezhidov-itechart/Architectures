using EquipmentManagement.Application.Equipments.Commands;
using EquipmentManagement.Infrastructura.Commands.Contracts;
using EquipmentManagement.Infrastructura.Events;

namespace EquipmentManagement.Application.Requets.Events.Handlers
{
    public class RequestApprovedEventHandler : EventHandlerBase<RequestApprovedEvent>
    {
        private readonly ICommandDispatcher commandDispatcher;

        public RequestApprovedEventHandler(ICommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        protected override void OnHandling(RequestApprovedEvent e)
        {
            commandDispatcher.Execute(new AddUserEquipmentCommand
            {
                RequestId = e.RequestId,
                EquipmentId = e.EquipmentId,
                ExpirationDate = e.ExpirationDate
            });
        }
    }
}
