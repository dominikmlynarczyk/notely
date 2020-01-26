using System.Threading.Tasks;

namespace Notely.SharedKernel.Application.Handlers
{
    public interface IQueryDispatcher
    {
        Task<TDto> Dispatch<TQuery, TDto>(TQuery query) where TQuery : IQuery;
    }
}