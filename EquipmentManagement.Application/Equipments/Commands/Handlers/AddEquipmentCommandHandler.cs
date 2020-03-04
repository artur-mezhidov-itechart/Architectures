using System.Threading;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Application.Equipments.Commands.Handlers
{
    public class AddEquipmentCommandHandler : CommandHandler<AddEquipmentCommand>
    {
        public AddEquipmentCommandHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override void OnHandling(AddEquipmentCommand command, CancellationToken token)
        {
            DataContext.Equipments.Add(new Equipment
            {
                Name = command.Name,
                Price = command.Price,
                Type = command.Type
            });
        }
    }
}
