using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Student_Course_Entity
{
    public class HumberContext : DbContext
    {
        public DbSet<TeacherPoco> Teachers { get; set; }
        public DbSet<StudentPoco> Students { get; set; }
        public DbSet<CoursePoco> Courses { get; set; }
        public DbSet<GradePoco> Grades { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlConnection());
            base.OnConfiguring(optionsBuilder);
        }
        private string SqlConnection()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            return root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherPoco>(
                entity =>
                {
                    entity.HasMany(t => t.TeacherToCourse).WithOne(c => c.CourseToTeacher);
                });
            modelBuilder.Entity<StudentPoco>(
                entity =>
                {
                    entity.HasOne(s => s.StudentToCourse).WithMany(c => c.CourseToStudent);
                    entity.HasMany(s => s.StudentToGrade).WithOne(g => g.GradeToStudent);
                });
            modelBuilder.Entity<CoursePoco>(
                entity =>
                {
                    entity.HasOne(c => c.CourseToTeacher).WithMany(t => t.TeacherToCourse)
                    .HasForeignKey(c => c.TeacherId).IsRequired();
                    //entity.HasMany(c => c.CourseToStudent).WithOne(sc => sc.);
                });

            modelBuilder.Entity<GradePoco>(
                entity =>
                {
                    entity.HasOne(g => g.GradeToCourse).WithMany(c => c.CourseToGrade).HasForeignKey(g => g.Course);
                    entity.HasOne(g => g.GradeToStudent).WithMany(g => g.StudentToGrade);
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
