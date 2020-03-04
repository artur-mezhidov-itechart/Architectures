using System;

namespace EquipmentManagement.Infrastructura.Commands.Exceptions
{
    public class CommandHandlerNotFoundException : CommandExceptionBase
    {
        public CommandHandlerNotFoundException(Type commandType, Exception innerException) : base(commandType, innerException)
        {
        }
    }
}
