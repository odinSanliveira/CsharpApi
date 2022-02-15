using CsharpApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsharpApi.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CourseDatabaseContext>
    {
        public CourseDatabaseContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<CourseDatabaseContext>();
            OptionsBuilder.UseSqlServer("Server=localhost;Database=API_COURSE;Trusted_Connection=True;");
            CourseDatabaseContext context = new CourseDatabaseContext(OptionsBuilder.Options);
            return context;
        }
    }
}
