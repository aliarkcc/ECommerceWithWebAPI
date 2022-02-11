using DataAccess.Concrete.EntityFramework.Mapping;
using Entities.Concrete.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Context
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }
        public DatabaseContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = MEHMETPC\\SQLEXPRESS; Initial Catalog=ECommerceWithWebAPIdb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        public virtual DbSet<User> Users{ get; set; }
    }
}
