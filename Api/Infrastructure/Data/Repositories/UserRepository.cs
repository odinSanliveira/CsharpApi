using CsharpApi.Business.Entities;
using CsharpApi.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsharpApi.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        CourseDatabaseContext _context;

        public UserRepository(CourseDatabaseContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.UserSet.Add(user);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public User GetUser(string login)
        {
            return _context.UserSet.FirstOrDefault(u => u.Login == login);
        }

        
    }

}
