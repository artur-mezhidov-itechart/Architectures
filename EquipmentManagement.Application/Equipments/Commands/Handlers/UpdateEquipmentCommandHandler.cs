using System.Threading;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Application.Equipments.Commands.Handlers
{
    public class UpdateEquipmentCommandHandler : CommandHandler<UpdateEquipmentCommand>
    {
        public UpdateEquipmentCommandHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override void OnHandling(UpdateEquipmentCommand command, CancellationToken token)
        {
            DataContext.Equipments.Update(new Equipment
            {
                Id = command.Id,
                Name = command.Name,
                Price = command.Price,
                Type = command.Type
            });
        }
    }
}
