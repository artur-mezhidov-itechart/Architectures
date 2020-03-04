namespace EquipmentManagement.Infrastructura.Commands.Contracts
{
    public interface ICommandDispatcher
    {
        void Execute<TCommand>() where TCommand : ICommand, new();

        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
