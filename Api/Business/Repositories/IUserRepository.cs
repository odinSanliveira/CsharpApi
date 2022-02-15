using CsharpApi.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsharpApi.Business.Repositories
{
    public interface IUserRepository
    {
        void Add(User userData);
        void Commit();
        User GetUser(string login);
    }
}
