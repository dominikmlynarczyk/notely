using System;
using System.Threading.Tasks;
using Autofac;

namespace Notely.SharedKernel.Application.Handlers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _componentContext;

        public QueryDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public async Task<TDto> Dispatch<TQuery, TDto>(TQuery query) where TQuery : IQuery
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var handler = _componentContext.Resolve<IQueryHandler<TQuery, TDto>>();
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return await handler.Handle(query);
        }
    }
}