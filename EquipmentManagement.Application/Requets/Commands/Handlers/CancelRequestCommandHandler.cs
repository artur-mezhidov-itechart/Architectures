using System.Threading;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Infrastructura.Commands.Contracts;

namespace EquipmentManagement.Application.Requets.Commands.Handlers
{
    public class CancelRequestCommandHandler : CommandHandler<CancelRequestCommand>
    {
        private readonly ICommandDispatcher commandDispatcher;

        public CancelRequestCommandHandler(DataContext dataContext, ICommandDispatcher commandDispatcher) : base(dataContext)
        {
            this.commandDispatcher = commandDispatcher;
        }

        protected override void OnHandling(CancelRequestCommand command, CancellationToken token)
        {
            commandDispatcher.Execute(new UpdateRequestStatusCommand(command.RequestId, RequestStatus.Canceled)
            {
                Message = command.Message
            });
        }
    }
}
