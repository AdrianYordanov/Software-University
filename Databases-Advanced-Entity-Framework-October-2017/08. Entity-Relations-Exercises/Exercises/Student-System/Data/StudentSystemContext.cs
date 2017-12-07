﻿namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.Configurations;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Student> Students
        {
            get;
            set;
        }

        public DbSet<Homework> HomeworkSubmissions
        {
            get;
            set;
        }

        public DbSet<Course> Courses
        {
            get;
            set;
        }

        public DbSet<Resource> Resources
        {
            get;
            set;
        }

        public DbSet<StudentCourse> StudentCourses
        {
            get;
            set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
        }
    }
}