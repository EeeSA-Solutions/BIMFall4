using BIMFall4.Data;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Authentication
{
       public class UserMasterRepository : IDisposable
       {
        // SECURITY_DBEntities it is your context class
        BIMFall4Context context = new BIMFall4Context();

        //This method is used to check and validate the user credentials
        public User ValidateUser(string email, string password)
        {
                var user = context.Users.Where(x => x.Email.Equals(email)
                && x.Password.Equals(password)).FirstOrDefault();
                if (user == null)
                {
                    return null;
                }
                else
                {
                    return user;
                }
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
    }
