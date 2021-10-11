using BIMFall4.Data;
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
            TestUsers = getUsers();
            
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

        public List<User> getUsers()
        {
            using (var db = new BIMFall4Context())
            {
                var u = db.Users.ToList();
                return u;
            }
        }
    }
}