using BIMFall4.Forms;
using BIMFall4.Manager;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        // GET: api/User


        // GET: api/User/5
        public User GetUserById(int id)
        {
            return UserManager.GetUserByID(id);
        }

        // POST: api/User
        public Response Post([FromBody] User value)
        {
            UserForm form = new UserForm(value);

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
