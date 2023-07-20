namespace InfomexProjekt.DbContext
{
    using InfomexProjekt.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja dla typu DateOnly
            modelBuilder.Entity<Student>()
                .Property(s => s.DataUrodzenia)
                .HasConversion(
                      v => v.ToDateTime(TimeOnly.MinValue),
                      v => DateOnly.FromDateTime(v)
                );
        }
    }
}
