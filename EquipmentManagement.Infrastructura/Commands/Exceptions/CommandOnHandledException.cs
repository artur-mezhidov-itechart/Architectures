using System;

namespace EquipmentManagement.Infrastructura.Commands.Exceptions
{
    public class CommandOnHandledException : CommandExceptionBase
    {
        public Type CommandHandlerType { get; }

        public CommandOnHandledException(Type commandType, Type commandHandlerType, Exception innerException) : base(commandType, innerException)
        {
            CommandHandlerType = commandHandlerType;
        }
    }
}
