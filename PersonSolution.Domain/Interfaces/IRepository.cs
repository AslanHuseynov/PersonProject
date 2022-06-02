using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonSolution.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BusinessObject
    {
        Task<int> CreateAsync(TEntity entity);
        Task<TEntity> ReadAsync(int id);
        Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> UpdateAsync(int id, TEntity entity);

    }
}
