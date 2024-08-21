using EF03.Configrations;
using Microsoft.EntityFrameworkCore;
using EF03.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF03.Contexts
{
    internal class DepartmentDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-2AMJ5HN ; Database = ITIEF03 ; Trusted_Connection = True ; Encrypt = False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Course>(new CourseConfigrations());
            modelBuilder.ApplyConfiguration<Course_Inst>(new Course_InstConfigrations());
            modelBuilder.ApplyConfiguration<Stud_Course>(new Stud_CourseConfigrations());
            modelBuilder.ApplyConfiguration<Student>(new StudentConfigrations());
            modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigrations());
            modelBuilder.ApplyConfiguration<Instructor>(new Instructoconfigrations());
            modelBuilder.ApplyConfiguration<Topic>(new TopicConfigrations());



        }

    }
}
