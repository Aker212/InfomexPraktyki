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

    }
}
