using CourseManagement.Library.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Library.Data
{
    public class SchoolContext : DbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<StudentResult> StudentResults { get; set; }
        public SchoolContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.EnableSensitiveDataLogging(true);
                optionBuilder.EnableDetailedErrors(true);
                optionBuilder.UseSqlServer(
                    _connectionString,
                    b => b.MigrationsAssembly(_migrationAssemblyName)
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Student>()
                        .HasIndex(s => s.Name)
                        .IsUnique();
            modelBuilder.Entity<Course>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Course>()
                        .HasIndex(c => c.Name)
                        .IsUnique();
            modelBuilder.Entity<Student>()
                         .Property(s => s.Id)
                         .HasDefaultValueSql("newid()");

            modelBuilder.Entity<Course>()
                        .Property(c => c.Id)
                        .HasDefaultValueSql("newid()");
            modelBuilder.Entity<Instructor>()
                        .Property(i => i.Id)
                        .HasDefaultValueSql("newid()");
            modelBuilder.Entity<Enrollment>()
                        .Property(i => i.Id)
                        .HasDefaultValueSql("newid()");
            modelBuilder.Entity<StudentResult>()
                        .Property(i => i.Id)
                        .HasDefaultValueSql("newid()");



            modelBuilder.Entity<Enrollment>()
                .HasIndex(t => new { t.StudentId, t.CourseId })
                .IsUnique();

            modelBuilder.Entity<Student>()
               .HasMany(t => t.Enrollments)
               .WithOne(t => t.Student)
               .HasForeignKey(t => t.StudentId);

            modelBuilder.Entity<Course>()
                .HasMany(t => t.Enrollments)
                .WithOne(t => t.Course)
                .HasForeignKey(t => t.CourseId);

            //modelBuilder.Entity<Course>()
            //    .HasOne(c => c.Prerequisite)
            //    .WithMany(c => c.Prerequisites)
            //    .HasForeignKey(c => c.PrerequisiteId)
            //    .OnDelete(DeleteBehavior.Cascade);

            // Many to One relationship between Student and StudenetResult
            modelBuilder.Entity<Student>()
               .HasMany(s => s.StudentResults)
               .WithOne(s => s.Student)
               .HasForeignKey(s => s.StudentId);

            // One to many relationship between Instructor and Course
            //modelBuilder.Entity<Instructor>()
            //    .HasMany(p => p.Courses)
            //    .WithOne(s => s.Instructor)
            //    .OnDelete(DeleteBehavior.Cascade);

            // Many to Many relationship between Students and Course
            //modelBuilder.Entity<Student>()
            //    .HasMany(p => p.Courses)
            //    .WithMany(s => s.Students);


            //Many to Many relationship between Student and Course
            //modelBuilder.Entity<StudentCourse>()
            //            .HasKey(sc => new { sc.StudentId, sc.CourseId });
            //modelBuilder.Entity<StudentCourse>()
            //    .HasOne(sc => sc.Student)
            //    .WithMany(s => s.Courses)
            //    .HasForeignKey(sc => sc.StudentId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<StudentCourse>()
            //    .HasOne(sc => sc.Course)
            //    .WithMany(d => d.Students)
            //    .HasForeignKey(sc => sc.CourseId)
            //    .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }


    }
}
