using Microsoft.EntityFrameworkCore;
using TestForBart.Core.Entities;
using TestForBart.Persistence.EntityConfigurations;

namespace TestForBart.Persistence
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new IncidentConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=.;Database=TestForBartDb;Integrated Security=SSPI;Encrypt=False;");

    }
}
