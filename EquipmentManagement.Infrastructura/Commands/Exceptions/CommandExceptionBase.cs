using System;

namespace EquipmentManagement.Infrastructura.Commands.Exceptions
{
    public abstract class CommandExceptionBase : Exception
    {
        public Type CommandType { get; }

        protected CommandExceptionBase(Type commandType) : this(commandType, null)
        {
        }

        protected CommandExceptionBase(Type commandType, Exception innerException) : base(innerException.Message, innerException)
        {
            CommandType = commandType;
        }
    }
}
