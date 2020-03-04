using System;
using Microsoft.Extensions.DependencyInjection;
using EquipmentManagement.Infrastructura.Commands.Contracts;
using EquipmentManagement.Infrastructura.Commands.Exceptions;

namespace EquipmentManagement.Infrastructura.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public virtual void Execute<TCommand>() where TCommand : ICommand, new()
        {
            Execute(new TCommand());
        }

        public virtual void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            ICommandHandler<TCommand> handler;

            try
            {
                handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            }
            catch (Exception exception)
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand), exception);
            }

            try
            {
                handler.Handle(command);
            }
            catch (CommandOnHandlingException exception)
            {
                // TODO: Logging
                throw exception;
            }
            catch (CommandOnHandledException exception)
            {
                // TODO: Logging
                throw exception;
            }
        }
    }
}
