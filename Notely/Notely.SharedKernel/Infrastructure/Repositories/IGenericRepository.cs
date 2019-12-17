using System;
using System.Collections.Generic;

namespace Notely.SharedKernel.Infrastructure.Repositories
{
    public interface IGenericRepository<TAggregate, TEntity> where TAggregate : AggregateRoot where TEntity : BaseDbEntity
    {
        TAggregate Get(Func<TEntity, bool> expression);
        IEnumerable<TAggregate> GetAll();
        void Add(TAggregate aggregateRoot);
        void Update(TAggregate aggregateRoot);
    }
}
