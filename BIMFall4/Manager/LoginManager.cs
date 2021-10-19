using BIMFall4.Authenticator;
using BIMFall4.Data;
using BIMFall4.Data.Secure;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Manager
{
    public class LoginManager
    {
        
        static public Response GetLoginResponse(User value)
        {
            TokenManager tokenManager = new TokenManager();
            var pw = new SecurePassword();
            

            using (var db = new BIMFall4Context())
            {
                value.Salt = GetUserSalt(value);
                value.Password = pw.ComputePassword(value);
                var user = db.Users.Where(x => x.Email.Equals(value.Email) && x.Password.Equals(value.Password)).FirstOrDefault();
                if (user == null)
                    return new Response { Status = "Invalid", Message = "Invalid User." };
                else

                    return new Response { Status = "Success", Message = "Login Successfully", UserID = user.ID, UserToken = tokenManager.GenerateToken(getUserId(value.Email)) };
            }
        }

        static public int getUserId(string email)
        {
            TokenManager tokenManager = new TokenManager();

            using (var db = new BIMFall4Context())
            {
                var u = db.Users.Where(x => x.Email == email).FirstOrDefault();
                db.SaveChanges();
                return u.ID;
            }
        }

        static public string GetUserSalt(User user)
        {
            using (var db = new BIMFall4Context())
            {
                var u = db.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                return u.Salt;
            }
        }
    }
}