using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace BIMFall4.Manager.JWTManager
{
    public class UserRepository
    {

        public List<User> TestUsers;
        public UserRepository()
        {
            TestUsers = new List<User>();
            TestUsers.Add(new User() { Email = "Test1@hotmail.com", Password = "Pass1" });
            TestUsers.Add(new User() { Email = "Test2@hotmail.com", Password = "Pass2" });
        }
        public User GetUser(string email)
        {
            try
            {
                return TestUsers.First(user => user.Email.Equals(email));
            }
            catch
            {
                return null;
            }
        }
    }
}