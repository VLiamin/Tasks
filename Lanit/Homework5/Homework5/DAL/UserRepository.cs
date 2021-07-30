using Homework5.Data;
using Homework5.Data.Models;
using System.Linq;

namespace Homework5.DAL
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
            var result = myDbContext.Users
                    .Where(b => b.Id == user.Id).FirstOrDefault();

            if (result == null)
            {
                myDbContext.Users.Add(user);
            }

            myDbContext.SaveChanges();
        }

        public void ChangeName(int Id, string name)
        {
            var result = myDbContext.Users
                    .Where(b => b.Id == Id).FirstOrDefault();
            result.Name = name;
            myDbContext.SaveChanges();
        }

        public void DeleteUser(int Id)
        {
            var result = myDbContext.Users.
                Where(b => b.Id == Id).FirstOrDefault();

            if (result != null)
            {
                myDbContext.Users.Remove(result);
                myDbContext.SaveChangesAsync();
            }
        }

        public User GetUser(int Id)
        {
            var result = myDbContext.Users.
                Where(b => b.Id == Id).FirstOrDefault();

            return result;
        }
    }
}
