using System.Threading;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Infrastructura.Commands.Contracts;

namespace EquipmentManagement.Application.Requets.Commands.Handlers
{
    public class DeclineRequestCommandHandler : CommandHandler<DeclineRequestCommand>
    {
        private readonly ICommandDispatcher commandDispatcher;

        public DeclineRequestCommandHandler(DataContext dataContext, ICommandDispatcher commandDispatcher) : base(dataContext)
        {
            this.commandDispatcher = commandDispatcher;
        }

        protected override void OnHandling(DeclineRequestCommand command, CancellationToken token)
        {
            commandDispatcher.Execute(new UpdateRequestStatusCommand(command.RequestId, RequestStatus.Declined)
            {
                Message = command.Message
            });
        }
    }
}
