using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Student.Models;
namespace Student.Data
{
    public class StdDBcontext : DbContext
    {
        public DbSet<Student1> Student1s { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<User> Users { get; set; }
        public StdDBcontext()
        {
        }
        public StdDBcontext(DbContextOptions<StdDBcontext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=DESKTOP-6T7E2SL\\SQLEXPRESS;Database=Student_Mange;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
