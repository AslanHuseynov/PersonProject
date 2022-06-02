using Microsoft.EntityFrameworkCore;
using PersonSolution.Domain;
using PersonSolution.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonSolution.Infrastructure.Implementations
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BusinessObject
    {
        protected readonly PersonDbContext personDbContext;
        public Repository(PersonDbContext personDbContext) => this.personDbContext = personDbContext;

        public IQueryable<TEntity> Entities => personDbContext.Set<TEntity>();

        // create
        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            personDbContext.Set<TEntity>().Add(entity);
            return await personDbContext.SaveChangesAsync();
        }
        // read
        public virtual async Task<TEntity> ReadAsync(int id)
        {
            return await personDbContext.Set<TEntity>().FindAsync(id);
        }
        public virtual async Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await personDbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }
        // update
        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            personDbContext.Set<TEntity>().Update(entity);
            return await personDbContext.SaveChangesAsync();
        }
        public virtual async Task<int> UpdateAsync(int id, TEntity entity)
        {
            var existing = personDbContext.Set<TEntity>().Find(id);
            personDbContext.Entry(existing).CurrentValues.SetValues(entity);
            return await personDbContext.SaveChangesAsync();
        }
        // delete

    }
}
