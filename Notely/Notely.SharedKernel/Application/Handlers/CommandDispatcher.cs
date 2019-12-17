using System;
using Autofac;

namespace Notely.SharedKernel.Application.Handlers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Func<Type, ICommandHandler> _commandHandlerFactory;

        public CommandDispatcher(Func<Type, ICommandHandler> commandHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            var handler = (ICommandHandler<TCommand>)_commandHandlerFactory(typeof(TCommand));
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            handler.Handle(command);
        }
    }
}