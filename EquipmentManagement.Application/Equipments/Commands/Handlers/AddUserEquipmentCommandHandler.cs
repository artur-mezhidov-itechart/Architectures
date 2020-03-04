using System;
using System.Threading;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Application.Equipments.Commands.Handlers
{
    public class AddUserEquipmentCommandHandler : CommandHandler<AddUserEquipmentCommand>
    {
        public AddUserEquipmentCommandHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override void OnHandling(AddUserEquipmentCommand command, CancellationToken token)
        {
            Request request = DataContext.Requests.Find(command.RequestId);

            if (request == null)
            {
                 throw new Exception($"Request {command.RequestId} not found.");
            }

            DataContext.UserEquipments.Add(new UserEquipment
            {
                UserId = request.UserId,
                EquipmentId = command.EquipmentId,
                RequestId = command.RequestId,
                ExpirationDate = command.ExpirationDate,
                ReceivedDate = DateTime.Now,
                IsReturned = false
            });
        }
    }
}
