﻿using BIMFall4.Data;
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
            using (var db = new BIMFall4Context())
            {
                var user = db.Users.Where(x => x.Email.Equals(value.Email) && x.Password.Equals(value.Password)).FirstOrDefault();
                if (user == null)
                    return new Response { Status = "Invalid", Message = "Invalid User." };
                else
                    return new Response { Status = "Success", Message = "Login Successfully", UserID = user.ID};
                    
            }
        }
    }
}