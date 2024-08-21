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
    internal class Course_InstConfigrations : IEntityTypeConfiguration<Course_Inst>
    {
        public void Configure(EntityTypeBuilder<Course_Inst> builder)
        {
            builder.ToTable("Course_Inst","dbo");
            builder.HasKey(e =>  new { e.Course_Id, e.Ins_Id });
            
           
        }
    }
}
