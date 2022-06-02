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
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PersonDbContext personDbContext) : base(personDbContext)
        {
                
        }

        public override Task<Person> ReadAsync(int id)
        {
            return Entities.Include(x => x.Sex).FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<IEnumerable<Person>> ReadAsync(Expression<Func<Person, bool>> predicate)
        {
            return await personDbContext.Set<Person>().Include(x => x.Sex).Where(predicate).ToListAsync();
        }
    }
}
