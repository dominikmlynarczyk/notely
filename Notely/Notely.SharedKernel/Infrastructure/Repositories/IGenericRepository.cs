using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Notely.SharedKernel.Infrastructure.Repositories
{
    public interface IGenericRepository<TAggregate, TEntity> where TAggregate : AggregateRoot where TEntity : BaseDbEntity
    {
        Task<TAggregate> Get(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TAggregate>> GetAll();
        Task Add(TAggregate aggregateRoot);
        Task Update(TAggregate aggregateRoot);
    }
}
