using System;
using System.Threading;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Requets.Events;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Infrastructura.Events.Contracts;
using EquipmentManagement.Security;

namespace EquipmentManagement.Application.Requets.Commands.Handlers
{
    public class CreateRequestCommandHandler : CommandHandler<CreateRequestCommand>
    {
        private Request request;

        private readonly IUserContext userContext;
        private readonly IEventDispatcher eventDispatcher;

        public CreateRequestCommandHandler(DataContext dataContext, IUserContext userContext, IEventDispatcher eventDispatcher) : base(dataContext)
        {
            this.userContext = userContext;
            this.eventDispatcher = eventDispatcher;
        }

        protected override void OnHandling(CreateRequestCommand command, CancellationToken token)
        {
            request = new Request
            {
                UserId = userContext.UserId,
                Message = command.Message,
                EquipmentType = command.EquipmentType,
                RequestedOn = DateTime.Now
            };

            DataContext.Requests.Add(request);
        }

        protected override void OnHandled(CreateRequestCommand command)
        {
            base.OnHandled(command);
            eventDispatcher.Publish(new RequestCreatedEvent(request));
        }
    }
}
