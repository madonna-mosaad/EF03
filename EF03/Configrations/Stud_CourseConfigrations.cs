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
    internal class Stud_CourseConfigrations : IEntityTypeConfiguration<Stud_Course>
    {
        public void Configure(EntityTypeBuilder<Stud_Course> builder)
        {
            builder.ToTable("Stud_Course", "dbo");
            builder.HasKey(e => new { e.Stud_Id, e.Course_Id });

        }
    }
}
