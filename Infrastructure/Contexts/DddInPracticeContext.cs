using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Contexts
{
    public class DddInPracticeContext : DbContext
    {
        public DddInPracticeContext(DbContextOptions<DddInPracticeContext> options): base(options)
        {          
        }

        public DddInPracticeContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

           if(!optionsBuilder.IsConfigured)
           {
                optionsBuilder.UseSqlServer("Server=localhost;Database=myDataBase;Trusted_Connection=True;TrustServerCertificate=True");
           }
        }

        public DbSet<SnackMachine> SnackMachines => Set<SnackMachine>();
    }
}
