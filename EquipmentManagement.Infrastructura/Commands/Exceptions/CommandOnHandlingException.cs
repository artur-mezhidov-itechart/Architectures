using System;

namespace EquipmentManagement.Infrastructura.Commands.Exceptions
{
    public class CommandOnHandlingException : CommandExceptionBase
    {
        public Type CommandHandlerType { get; }

        public CommandOnHandlingException(Type commandType, Type commandHandlerType, Exception innerException) : base(commandType, innerException)
        {
            CommandHandlerType = commandHandlerType;
        }
    }
}
