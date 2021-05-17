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

        static public User GetUserByEmail(string email)
        {
            using (var db = new BIMFall4Context())
            {
              return GetUserByEmail(email, db);
            }
        }

        static public User GetUserByEmail(string email, BIMFall4Context db)
        {
            return db.Users.Where(user => user.Email == email).FirstOrDefault();
        }
    }
}