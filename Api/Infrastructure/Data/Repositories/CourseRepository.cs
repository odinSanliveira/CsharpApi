using CsharpApi.Business.Entities;
using CsharpApi.Business.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsharpApi.Infrastructure.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseDatabaseContext _context;

        public CourseRepository(CourseDatabaseContext context)
        {
            _context = context;
        }

        public void AddCourse(Course course)
        {
            _context.CourseSet.Add(course);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Course> GetByUser(int userCode)
        {
            return _context.CourseSet.Include(i => i.User).Where(w => w.UserCode == userCode).ToList();
        }
    }
}
