using PersonSolution.Domain;
using PersonSolution.Domain.Interfaces;

namespace PersonSolution.Infrastructure.Implementations
{
    public class SexRepository : Repository<Sex>, ISexRepository
    {
        public SexRepository(PersonDbContext sexDbContext) : base(sexDbContext)
        {

        }
    }
}
