﻿using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Diagnostics;
using System.Reflection.Metadata;
using exercise.wwwapi.DataModels;


namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        //private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options): base(options) {

        //    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;

         //   this.Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(_connectionString);
            // optionsBuilder.LogTo(message => Debug.WriteLine(message));
       // }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CourseStudent>().HasKey(e => new { e.CourseId, e.StudentId });

            // modelBuilder.Entity<Course>().HasMany(e => e.Students).WithOne(e => e.Course).HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Course>().HasData(
             new Course { Id = 1, Title = "Math", Teacher = "Ms. Rosamund", StartDate = DateTime.Now.ToUniversalTime() },
             new Course { Id = 2, Title = "Literature", Teacher = "Mr. Dostoyevski", StartDate = DateTime.Now.ToUniversalTime() },
             new Course { Id = 3, Title = "Arts", Teacher = "Mr. Bacon", StartDate = DateTime.Now.ToUniversalTime() });


            List<Student> students = new List<Student>();
            students.Add(new Student { Id = 1, FirstName = "Sandra", LastName = "Collins", DOB = DateTime.Now.ToUniversalTime(), AverageGrade = 3.0F });
            students.Add(new Student { Id = 2, FirstName = "Mike", LastName = "Smith", DOB = DateTime.Now.ToUniversalTime(), AverageGrade = 4.0F  });
            students.Add(new Student { Id = 3, FirstName = "Heather", LastName = "Dunst", DOB = DateTime.Now.ToUniversalTime(), AverageGrade = 5.0F  });

            modelBuilder.Entity<Student>().HasData(students);

            List<CourseStudent> mps = new List<CourseStudent>();
            mps.Add(new CourseStudent { StudentId = 1, CourseId = 1 });
            mps.Add(new CourseStudent { StudentId = 1, CourseId = 3 });
            mps.Add(new CourseStudent { StudentId = 2, CourseId = 2 });
            mps.Add(new CourseStudent { StudentId = 3, CourseId = 3 });
            modelBuilder.Entity<CourseStudent>().HasData(mps);


        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
    }
}
