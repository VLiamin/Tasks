using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Models;

namespace WebService2.DAL
{
    public interface IUserRepository
    {
        string AddUser(User user);
        string DeleteUser(int Id);
        List<User> GetAllUsers();
        User GetUser(int Id);
    }
}
