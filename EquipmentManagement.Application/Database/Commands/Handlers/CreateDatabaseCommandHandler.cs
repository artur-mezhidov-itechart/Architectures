using System.Threading;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain.Data;

namespace EquipmentManagement.Application.Database.Commands.Handlers
{
    public class CreateDatabaseCommandHandler : CommandHandler<CreateDatabaseCommand>
    {
        public CreateDatabaseCommandHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override void OnHandling(CreateDatabaseCommand command, CancellationToken token)
        {
            DataContext.Database.EnsureCreated();
        }
    }
}
