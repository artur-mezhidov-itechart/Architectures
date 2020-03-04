using System;
using System.Threading;
using EquipmentManagement.Infrastructura.Commands.Contracts;
using EquipmentManagement.Infrastructura.Commands.Exceptions;

namespace EquipmentManagement.Infrastructura.Commands
{
    public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly CancellationTokenSource cancelTokenSource;

        protected CommandHandlerBase()
        {
            cancelTokenSource = new CancellationTokenSource();
        }

        protected abstract void OnHandling(TCommand command, CancellationToken token);

        protected abstract void OnHandled(TCommand command);

        public void Handle(TCommand command)
        {
            try
            {
                OnHandling(command, cancelTokenSource.Token);
            }
            catch (Exception exception)
            {
                throw new CommandOnHandlingException(typeof(TCommand), GetType(), exception);
            }

            if (cancelTokenSource.IsCancellationRequested)
            {
                return;
            }

            try
            {
                OnHandled(command);
            }
            catch (Exception exception)
            {
                throw new CommandOnHandledException(typeof(TCommand), GetType(), exception);
            }
        }

        protected virtual void Cancel()
        {
            cancelTokenSource.Cancel();
        }
    }
}
