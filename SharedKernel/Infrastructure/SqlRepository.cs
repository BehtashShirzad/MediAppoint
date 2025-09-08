using CSharpFunctionalExtensions;

using Microsoft.EntityFrameworkCore;
using SharedKernel.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Infrastructure
{
    public abstract class SqlRepository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : SharedKernel.Domain.Entity<TId>
    where TId : IEquatable<TId>
    {
        protected readonly DbContext context;
        protected readonly DbSet<TEntity> set;

        public SqlRepository(DbContext context)
        {
            this.context = context;
            set = context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await set.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity, CancellationToken cts = default)
        {
            await set.AddAsync(entity,cts);
        }

        public Task UpdateAsync(TEntity entity)
        {
            set.Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity)
        {
            set.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IReadOnlyCollection<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> predicate
        )
        {
            return await set.Where(predicate).ToListAsync();
        }
    }
}
