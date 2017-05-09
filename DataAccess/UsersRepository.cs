using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataAccess
{
    public class UsersRepository : Connection
    {
        public UsersRepository() : base()
        { }

        public IQueryable<User> GetUsers()
        {
            return Entity.Users;
        }

        public User GetUser(string username)
        {

            return Entity.Users.SingleOrDefault(x => x.Username == username);
        }

        public bool AuthenticateUser(string username, string password)
        {
            if ((Entity.Users.SingleOrDefault(x => x.Username == username && x.Password == password)) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddUser(User u)
        {
            Entity.Users.Add(u);
            Entity.SaveChanges();
        }

        public void DeleteUser(User u)
        {
            Entity.Users.Remove(u);
            Entity.SaveChanges();
        }

        public void EditUser(User u)
        {
            Entity.Entry(GetUser(u.Username)).CurrentValues.SetValues(u);
            Entity.SaveChanges();
        }
    }
}
