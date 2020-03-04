using System;
using System.Threading;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Security;

namespace EquipmentManagement.Application.Requets.Commands.Handlers
{
    public class UpdateRequestStatusCommandHandler : CommandHandler<UpdateRequestStatusCommand>
    {
        private readonly IUserContext userContext;

        public UpdateRequestStatusCommandHandler(DataContext dataContext, IUserContext userContext) : base(dataContext)
        {
            this.userContext = userContext;
        }

        protected override void OnHandling(UpdateRequestStatusCommand command, CancellationToken token)
        {
            DataContext.RequestStatusInfo.Add(new RequestStatusInfo
            {
                RequestId = command.RequestId,
                Status = command.Status,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userContext.UserId,
                Message = command.Message
            });
        }
    }
}
