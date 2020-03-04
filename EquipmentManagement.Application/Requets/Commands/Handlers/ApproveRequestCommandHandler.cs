using System.Threading;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Requets.Events;
using EquipmentManagement.Domain;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Infrastructura.Commands.Contracts;
using EquipmentManagement.Infrastructura.Events.Contracts;

namespace EquipmentManagement.Application.Requets.Commands.Handlers
{
    public class ApproveRequestCommandHandler : CommandHandler<ApproveRequestCommand>
    {
        private readonly ICommandDispatcher commandDispatcher;
        private readonly IEventDispatcher eventDispatcher;

        public ApproveRequestCommandHandler(DataContext dataContext, ICommandDispatcher commandDispatcher, IEventDispatcher eventDispatcher) : base(dataContext)
        {
            this.commandDispatcher = commandDispatcher;
            this.eventDispatcher = eventDispatcher;
        }

        protected override void OnHandling(ApproveRequestCommand command, CancellationToken token)
        {
            commandDispatcher.Execute(new UpdateRequestStatusCommand(command.RequestId, RequestStatus.Approved)
            {
                Message = command.Message
            });

            eventDispatcher.Publish(new RequestApprovedEvent
            {
                RequestId = command.RequestId,
                EquipmentId = command.EquipmentId,
                ExpirationDate = command.ExpirationDate
            });
        }
    }
}
