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
        public DbSet<Kurs> Kursy { get; set; }
        public DbSet<KursyStudentow> KursyStudentow { get; set; }
        public DbSet<Wydzial> Wydzial {get ; set; }
        public DbSet<Adres> Adres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Relacje
            //Wydzial a student
            modelBuilder.Entity<Wydzial>()
             .HasKey(w => w.IdWydzialu);

            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Wydzial)
                .WithMany() // Brak odwrotnej relacji w klasie Wydzial
                .HasForeignKey(s => s.IdWydzialu);


            //Kursy Studentów (studenci + kursy)
            modelBuilder.Entity<KursyStudentow>()
             .HasKey(ks => new { ks.IdStudenta, ks.IdKursu });

            modelBuilder.Entity<KursyStudentow>()
                .HasOne(ks => ks.Student)
                .WithMany()
                .HasForeignKey(ks => ks.IdStudenta);

            modelBuilder.Entity<KursyStudentow>()
                .HasOne(ks => ks.Kurs)
                .WithMany()
                .HasForeignKey(ks => ks.IdKursu);



            //Adres a student
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Adres)          // Student ma jeden Adres
                .WithMany()                    // Adres nie ma odwrotnej relacji z Studentem
                .HasForeignKey(s => s.IdAdresu); // Klucz obcy Student.IdAdresu wskazuje na klucz główny Adres.IdAdresu

            #endregion

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
