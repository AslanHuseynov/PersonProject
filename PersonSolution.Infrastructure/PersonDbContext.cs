using Microsoft.EntityFrameworkCore;
using PersonSolution.Domain;

namespace PersonSolution.Infrastructure
{
    public class PersonDbContext : DbContext
    {

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Sex> Sexes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
            .HasOne(p => p.Sex)
            .WithMany(e => e.Persons)
            .HasForeignKey(x => x.SexId).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
