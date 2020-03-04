using System.Linq;
using System.Threading;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Application.Equipments.Commands.Handlers
{
    public class ReturnEquipmentCommandHandler : CommandHandler<ReturnEquipmentCommand>
    {
        public ReturnEquipmentCommandHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override void OnHandling(ReturnEquipmentCommand command, CancellationToken token)
        {
            UserEquipment equipment = DataContext.UserEquipments.FirstOrDefault(i => i.RequestId == command.RequestId);

            if (equipment == null)
            {
                Cancel();
            }
            else
            {
                equipment.IsReturned = true;
            }
        }
    }
}
