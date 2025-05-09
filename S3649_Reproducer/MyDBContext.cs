using Microsoft.EntityFrameworkCore;

namespace S3649_Reproducer
{
    public class MyDBContext : DbContext
    {
        public DbSet<Entity1> Entity1s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entity1>();
        }
    }
}
