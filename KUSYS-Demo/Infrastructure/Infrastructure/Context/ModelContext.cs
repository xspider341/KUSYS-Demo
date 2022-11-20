using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
            //Data seeds
            //IList<Course> defaultCourses = new List<Course>
            //{
            //    new Course() { CourseName = "Object Oriented Programming" },
            //    new Course() { CourseName = "Introduction to Computer Science" },
            //    new Course() { CourseName = "Algorithms" },
            //    new Course() { CourseName = "Calculus" },
            //    new Course() { CourseName = "Physics" }
            //};

            //IList<User> defaultUsers = new List<User>
            //{
            //    new User() { UserName = "emin", Password = "123", Role = 1 },
            //    new User() { UserName = "user", Password = "123", Role = 2 }
            //};


            //User.AddRange(defaultUsers);
            //Course.AddRange(defaultCourses);

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course{ get; set; }
        public DbSet<User> User { get; set; }




        

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
