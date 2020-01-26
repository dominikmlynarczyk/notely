using System;
using System.Threading.Tasks;
using Autofac;

namespace Notely.SharedKernel.Application.Handlers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _componentContext;

        public CommandDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public async Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var handler = _componentContext.Resolve<ICommandHandler<TCommand>>();
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            await handler.Handle(command);
        }
    }
}