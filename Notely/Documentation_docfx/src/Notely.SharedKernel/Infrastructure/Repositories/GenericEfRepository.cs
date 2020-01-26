using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
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

        public async Task<TAggregate> Get(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await Set.SingleOrDefaultAsync(expression, CancellationToken.None);
            return Mapper.Map<TAggregate>(entity);
        }

        public async Task<IEnumerable<TAggregate>> GetAll()
        {
            var elements = await Set.ToListAsync();
            return Mapper.Map<IEnumerable<TAggregate>>(elements);
        }

        public async Task Add(TAggregate aggregateRoot)
        {
            var entity = Mapper.Map<TEntity>(aggregateRoot);
            Set.Add(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(TAggregate aggregateRoot)
        {
            var entity = Mapper.Map<TEntity>(aggregateRoot);
            var entityInDb = Set.SingleOrDefault(x => x.Id == entity.Id);
            UpdateExistingEntityWithUpdatedEntity(entityInDb, entity);
            Set.Update(entityInDb);
            await Context.SaveChangesAsync();
        }

        private void UpdateExistingEntityWithUpdatedEntity(TEntity entity, TEntity updatedEntity)
        {
            var properties = entity.GetType().GetProperties();
            foreach (var propertyInfo in properties)
            {
                propertyInfo.SetValue(entity, updatedEntity.GetType().GetProperty(propertyInfo.Name).GetValue(updatedEntity));
            }
        }
    }
}