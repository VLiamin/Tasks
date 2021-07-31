using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddUser(User user)
        {
            throw new NotImplementedException();
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

        public void GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(int Id)
        {
            var result = myDbContext.Users.
                Where(b => b.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
