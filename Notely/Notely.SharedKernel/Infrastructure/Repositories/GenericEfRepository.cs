using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Notely.SharedKernel.Infrastructure.Repositories
{
    public class GenericEfRepository<TAggregate, TEntity> : IGenericRepository<TAggregate, TEntity> where TAggregate : AggregateRoot where TEntity : BaseDbEntity
    {
        protected readonly DbContext Context;
        protected readonly IMapper Mapper;
        protected DbSet<TEntity> Set => Context.Set<TEntity>();

        public GenericEfRepository(DbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public TAggregate Get(Func<TEntity, bool> expression)
            => Mapper.Map<TAggregate>(Set.SingleOrDefault(expression));

        public IEnumerable<TAggregate> GetAll()
            => Mapper.Map<IEnumerable<TAggregate>>(Set.ToList());

        public void Add(TAggregate aggregateRoot)
        {
            var entity = Mapper.Map<TEntity>(aggregateRoot);
            Set.Add(entity);
            Context.SaveChanges();
        }

        public void Update(TAggregate aggregateRoot)
        {
            var entity = Mapper.Map<TEntity>(aggregateRoot);
            var entityInDb = Set.SingleOrDefault(x => x.Id == entity.Id);
            entityInDb = entity;
            Set.Update(entityInDb);
            Context.SaveChanges();
        }
    }
}