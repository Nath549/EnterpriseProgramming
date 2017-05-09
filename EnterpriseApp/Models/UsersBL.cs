using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using DataAccess;
using System.Web;

namespace EnterpriseApp.Models
{
    public enum RegistrationEnum { Success, UserNameExists, ErrorOccurred };
    public enum LoginEnum { Success, InvalidCredentials };

    public class UsersBL
    {
        UsersRepository ur = new UsersRepository();

        public User GetUser(string username)
        {
            return ur.GetUser(username);
        }

        public IQueryable<User> GetUsers()
        {
            return ur.GetUsers();
        }

        public RegistrationEnum RegisterUser(User u)
        {
            if (ur.GetUser(u.Username) == null)
            {
                try
                {
                    {
                        ur.AddUser(u);
                        return RegistrationEnum.Success;
                    }
                }

                catch(Exception e)
                {
                    return RegistrationEnum.ErrorOccurred;

                }
            }

            else
            {
                return RegistrationEnum.UserNameExists;
            }
        }

        public void DeleteUser(string username)
        {
            ur.DeleteUser(ur.GetUser(username));
        }

        public LoginEnum Login(string username, string password)
        {
            if (ur.AuthenticateUser(username, password))
            {
                return LoginEnum.Success;
            }
            else
            {
                return LoginEnum.InvalidCredentials;
            }
        }

        public void EditUser(User u)
        {
            ur.EditUser(u);
        }
    }
}