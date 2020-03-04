using EquipmentManagement.Domain.Data;
using EquipmentManagement.Infrastructura.Commands;
using EquipmentManagement.Infrastructura.Commands.Contracts;

namespace EquipmentManagement.Application.Common
{
    public abstract class CommandHandler<TCommand> : CommandHandlerBase<TCommand> where TCommand : ICommand
    {
        protected DataContext DataContext { get; }

        protected CommandHandler(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        protected override void OnHandled(TCommand command)
        {
            DataContext.SaveChanges();
        }
    }
}
