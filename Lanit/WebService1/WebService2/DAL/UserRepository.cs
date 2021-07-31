using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService1.Models;

namespace WebService2.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext myDbContext;

        public UserRepository(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public string AddUser(User user)
        {
            var result = myDbContext.Users
                    .Where(b => b.Id == user.Id).FirstOrDefault();

            if (result != null)
            {
                return "This elelment is exists";
            }

            myDbContext.Users.Add(user);
            myDbContext.SaveChanges();
            return "Succes";
        }

        public string DeleteUser(int Id)
        {
            var result = myDbContext.Users.
                Where(b => b.Id == Id).FirstOrDefault();
            if (result == null)
            {
                return "This elelment is not exists";
            }
            myDbContext.Users.Remove(result);
            myDbContext.SaveChanges();
            return "Succes";
        }

        public List<User> GetAllUsers()
        {
            List<User> users = myDbContext.Users.ToList();
            
            return users;
        }

        public User GetUser(int Id)
        {
            var result = myDbContext.Users.
                Where(b => b.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
