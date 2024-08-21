using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF03.Entities;

namespace EF03.Configrations
{
    internal class StudentConfigrations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students", "dbo");
            builder.HasKey(e => e.SId);
            builder.HasOne(e => e.Department).WithMany(e => e.Students);
            builder.Property(e => e.SId).UseIdentityColumn(10, 10);
            builder.Property(e => e.Address).HasDefaultValue("Cairo");
            builder.HasMany(s => s.Courses).WithOne(sc => sc.Student);

        }
    }
}
