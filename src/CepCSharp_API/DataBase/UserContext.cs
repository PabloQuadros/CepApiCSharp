using CepCSharp_API.Entities.DomainEntities;
using Microsoft.EntityFrameworkCore;

namespace CepCSharp_API.DataBase
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString:
                "Server=localhost;Port=5432;User Id=postgres;Password=admin123;Database=postgres");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
