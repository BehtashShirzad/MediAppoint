using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain.Contracts
{
    public interface IRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : IEquatable<TId>
    {
        Task<TEntity?> GetByIdAsync(TId id);
        Task AddAsync(TEntity entity,CancellationToken cts=default);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<IReadOnlyCollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }


    public interface IReadRepository<TEntity, TId>
       where TEntity : IEntity<TId>
       where TId : IEquatable<TId>
    {
        Task<TEntity?> GetByIdAsync(TId id);
           
        Task<IReadOnlyCollection<TEntity>> FindQueryAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
