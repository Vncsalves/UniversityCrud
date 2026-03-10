using Microsoft.EntityFrameworkCore;
using UniversityCrud.Business.Entities; 

namespace UniversityCrud.Data.Contexts
{
    public class DataContext : DbContext
    {
 
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("student").HasKey(s => s.Id);
            modelBuilder.Entity<Course>().ToTable("course").HasKey(c => c.Id);
            modelBuilder.Entity<Class>().ToTable("class").HasKey(c => c.Id);
            modelBuilder.Entity<Enrollment>().ToTable("enrollment").HasKey(e => e.Id);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Classes)
                .WithOne(cl => cl.Course)
                .HasForeignKey(cl => cl.CourseId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Class>()
                .HasMany(c => c.Enrollments)
                .WithOne(e => e.Class)
                .HasForeignKey(e => e.ClassId);

            base.OnModelCreating(modelBuilder);
        }
    }
}