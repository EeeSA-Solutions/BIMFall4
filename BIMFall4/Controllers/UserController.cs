﻿using BIMFall4.Forms;
using BIMFall4.Manager;
using BIMFall4.Models;
using BIMFall4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity;

namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        // GET: api/User
        public IQueryable<UserDto> GetUser(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var user = from x in db.Users
                           select new UserDto()
                           {
                               UserID = x.UserID,
                               FirstName = x.FirstName,
                               LastName = x.LastName,
                               Email = x.Email
                           };
                return user;
            }
        }

        //googla - - - eagerload relations

        //GET: api/User/5
        //public User GetUserById(int id)
        //{
        //    return UserManager.GetUserByID(id);
        //}

        // POST: api/User
        public Response Post([FromBody] User value)
        {
            var form = new UserForm(value);

            if (form.isValid())
            {
                UserManager.CreateUser(value);
                return new Response { Status = "Valid" };
            }
            else
            {
                return new Response { Status = "Invalid", Message = form.ErrorMessage };
            }

        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
