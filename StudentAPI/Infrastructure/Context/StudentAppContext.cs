using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class StudentAppContext : DbContext
    {

        public StudentAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Student

            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Student>()
                .Property(p => p.Imie)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Student>()
                .Property(p => p.Nazwisko)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Student>()
                .Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Student>()
                .Property(p => p.RokRozpoczencia)
                .IsRequired();
            modelBuilder.Entity<Student>()
                .Property(s => s.DataUrodzenia)
                .HasConversion(
                      v => v.ToDateTime(TimeOnly.MinValue),
                      v => DateOnly.FromDateTime(v)
                );

            #endregion
        }
    }
}
