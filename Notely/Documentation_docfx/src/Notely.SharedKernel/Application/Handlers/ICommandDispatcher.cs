using System.Threading.Tasks;

namespace Notely.SharedKernel.Application.Handlers
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}