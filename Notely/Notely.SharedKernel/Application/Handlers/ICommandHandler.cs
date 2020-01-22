using System.Threading.Tasks;

namespace Notely.SharedKernel.Application.Handlers
{

    public interface ICommandHandler
    {

    }
    public interface ICommandHandler<TCommand> : ICommandHandler where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }

}
