using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BIMFall4.Models;
using BIMFall4.Data;

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

        static public User GetUserByID(int id)
        {
            using (var db = new BIMFall4Context())
            {
                return db.Users.Find(id);
            }
        }

        static public User GetUserByEmail(string email)
        {
            using (var db = new BIMFall4Context())
            {
                return db.Users.Where(user => user.Email == email).SingleOrDefault(); // error om det finns dubbel
            }
        }

        static public IEnumerable<User> SearchByFirstName(string firstName)
        {
            using (var db = new BIMFall4Context())
            {
                return db.Users.Where(user => user.FirstName == firstName);
            }
        }


        // search friends
        // add friend
        // remove friend
    }
}