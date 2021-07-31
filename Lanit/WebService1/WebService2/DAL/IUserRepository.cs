using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Models;

namespace WebService2.DAL
{
    public interface IUserRepository
    {
        void AddUser(User user);
        string DeleteUser(int Id);
        void GetAllUsers();
        User GetUser(int Id);
    }
}
