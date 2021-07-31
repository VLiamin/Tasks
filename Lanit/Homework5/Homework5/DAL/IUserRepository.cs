using Homework5.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework5.DAL
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DeleteUser(int Id);
        void ChangeName(int id, string name);
        User GetUser(int Id);
    }
}
