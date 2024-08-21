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
    internal class TopicConfigrations : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topics", "dbo");
            builder.HasKey(e => e.TId);
            builder.Property(e => e.TId).UseIdentityColumn(10, 10);

        }
    }
}
