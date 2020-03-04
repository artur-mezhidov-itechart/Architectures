using System.Threading;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Requets.Events;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Infrastructura.Events.Contracts;
using EquipmentManagement.Security;

namespace EquipmentManagement.Application.Requets.Commands.Handlers
{
    public class AssigneRequestCommandHandler : CommandHandler<AssigneRequestCommand>
    {
        private readonly IUserContext userContext;
        private readonly IEventDispatcher eventDispatcher;

        public AssigneRequestCommandHandler(DataContext dataContext, IUserContext userContext, IEventDispatcher eventDispatcher) : base(dataContext)
        {
            this.userContext = userContext;
            this.eventDispatcher = eventDispatcher;
        }

        protected override void OnHandling(AssigneRequestCommand command, CancellationToken token)
        {
            Request request = DataContext.Requests.Find(command.RequestId);

            if (request == null)
            {
                return;
            }

            request.AssignedUserId = userContext.UserId;

            DataContext.Requests.Update(request);
        }

        protected override void OnHandled(AssigneRequestCommand command)
        {
            base.OnHandled(command);
            eventDispatcher.Publish(new RequestAssignedEvent(command.RequestId));
        }
    }
}
