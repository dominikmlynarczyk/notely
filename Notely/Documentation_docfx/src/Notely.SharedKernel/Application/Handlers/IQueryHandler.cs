using System.Threading.Tasks;

namespace Notely.SharedKernel.Application.Handlers
{
    public interface IQueryHandler<TQuery, TDto> : ICommandHandler where TQuery : IQuery
    {
        Task<TDto> Handle(TQuery query);
    }

}