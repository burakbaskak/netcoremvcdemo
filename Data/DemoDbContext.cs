using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data{
    public class DemoDbContext : DbContext{

        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
            
        }

        public DemoDbContext()
        {
            
        }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
}

        public DbSet<Company> Comapnies { get; set; }

    }
}