using CsharpApi.Business.Entities;
using CsharpApi.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsharpApi.Infrastructure.Data
{
    public class CourseDatabaseContext : DbContext
    {
        public CourseDatabaseContext(DbContextOptions<CourseDatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> DbUser { get; set; }
    }
}
