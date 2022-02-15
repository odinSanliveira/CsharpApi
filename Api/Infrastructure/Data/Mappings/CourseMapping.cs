using CsharpApi.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsharpApi.Infrastructure.Data.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            //course database
            builder.ToTable("TB_COURSE");
            builder.HasKey(p => p.Code);
            builder.Property(p => p.Code).ValueGeneratedOnAdd();
            builder.Property(p => p.Title);
            builder.Property(p => p.Description);
            builder.HasOne(p => p.User)
                .WithMany().HasForeignKey(fk => fk.UserCode);
        }
    }
}
