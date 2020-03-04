using System.Threading;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Equipments.Queries;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Infrastructura.Queries.Contracts;

namespace EquipmentManagement.Application.Equipments.Commands.Handlers
{
    public class DeleteEquipmentCommandHandler : CommandHandler<DeleteEquipmentCommand>
    {
        private readonly IQueryDispatcher dispatcher;

        public DeleteEquipmentCommandHandler(DataContext dataContext, IQueryDispatcher dispatcher) : base(dataContext)
        {
            this.dispatcher = dispatcher;
        }

        protected override void OnHandling(DeleteEquipmentCommand command, CancellationToken token)
        {
            Equipment equipment = dispatcher.Execute(new GetEquipmentByIdQuery(command.Id));

            if (equipment == null)
            {
                Cancel();
            }
            else
            {
                DataContext.Equipments.Remove(equipment);
            }
        }
    }
}
