using System.Threading;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Infrastructura.Commands.Contracts;

namespace EquipmentManagement.Application.Requets.Commands.Handlers
{
    public class CompleteRequestCommandHandler : CommandHandler<CompleteRequestCommand>
    {
        private readonly ICommandDispatcher commandDispatcher;

        public CompleteRequestCommandHandler(DataContext dataContext, ICommandDispatcher commandDispatcher) : base(dataContext)
        {
            this.commandDispatcher = commandDispatcher;
        }

        protected override void OnHandling(CompleteRequestCommand command, CancellationToken token)
        {
            commandDispatcher.Execute(new UpdateRequestStatusCommand(command.RequestId, RequestStatus.Completed));
        }
    }
}
