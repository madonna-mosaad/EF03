using EF03.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF03.Configrations
{
    internal class CourseConfigrations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses", "dbo");
            builder.HasKey(e => e.CId);
            builder.HasOne(e => e.Topic).WithMany(e => e.Courses);
            builder.Property(e => e.CId).UseIdentityColumn(10, 10);
            builder.HasMany(c => c.Students).WithOne(sc => sc.Course);
            builder.HasMany(i => i.Instructors).WithOne(ic => ic.Course);
        }
    }
}
