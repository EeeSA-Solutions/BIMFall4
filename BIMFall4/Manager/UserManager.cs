using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BIMFall4.Models;
using BIMFall4.Data;
using BIMFall4.ModelDTO;
using System.Data.Entity;

namespace BIMFall4.Manager
{
    public class UserManager
    {
        static public void CreateUser(User user)
        {
            using (var db = new BIMFall4Context())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        static public void RemoveUser(int id)
        {
            using (var db = new BIMFall4Context())
            {
                if(db.Users.Find(id) != null)
                { 
                    db.Users.Remove(db.Users.Find(id));
                    db.SaveChanges();
                }
            }
        }

        static public UserDTO GetUserById(int id)
        {

            using (var db = new BIMFall4Context())
            {
                var user = db.Users.FirstOrDefault(x => x.ID == id);
                //var user = db.Users.Where(s => s.ID == id).Include(u => u.Pendings).FirstOrDefault()
                
                var userdto = new UserDTO
                {
                    ID = user.ID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                };
                return userdto;
            }
        }

        static public User GetSafeUserByID(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var SafeUser = db.Users.Find(id);
                //SafeUser.Password = "";
                return SafeUser;
            }
        }

        static public User GetUserByEmail(string email)
        {
            using (var db = new BIMFall4Context())
            {
              return GetUserByEmail(email, db);
            }
        }
        static public dynamic GetUserByEmail(string email, BIMFall4Context db)
        {
            var checkemail = db.Users.Where(user => user.Email == email).FirstOrDefault();

            if (checkemail == null)
            {
                return "User does not exist";
            }
            else
            {
                return checkemail;
            }
        }

        static public IEnumerable<User> SearchByFirstName(string firstName)
        {
            using (var db = new BIMFall4Context())
            {
                return db.Users.Where(user => user.FirstName == firstName);
            }
        }
    }
}