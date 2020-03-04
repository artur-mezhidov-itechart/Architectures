namespace EquipmentManagement.Infrastructura.Commands.Contracts
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
