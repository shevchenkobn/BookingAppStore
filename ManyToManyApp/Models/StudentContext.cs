using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ManyToManyApp.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public StudentContext() : base("DefaultConnection")
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .Map(t => t.MapLeftKey("CourseId")
                .MapRightKey("StudentId")
                .ToTable("CourseStudent"));
        }
    }

    public class StudentDbInitializer : DropCreateDatabaseAlways<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            var s1 = new Student { Id = 1, Name = "Yegor", Surname = "Ivanov" };
            var s2 = new Student { Id = 2, Name = "Maria", Surname = "Vasilyeva" };
            var s3 = new Student { Id = 3, Name = "Oleg", Surname = "Kuznetsov" };
            var s4 = new Student { Id = 4, Name = "Olga", Surname = "Petrova" };

            context.Students.Add(s1);
            context.Students.Add(s2);
            context.Students.Add(s3);
            context.Students.Add(s4);

            var c1 = new Course
            {
                Id = 1,
                Name = "Operational systems",
                Students = new List<Student> { s1, s2, s3 }
            };
            var c2 = new Course
            {
                Id = 2,
                Name = "Algorithm and data structures",
                Students = new List<Student> { s2, s4 }
            };
            var c3 = new Course
            {
                Id = 3,
                Name = "HTML and CSS basics",
                Students = new List<Student> { s1, s4, s3 }
            };

            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.Courses.Add(c3);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}