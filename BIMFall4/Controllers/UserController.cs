using BIMFall4.Forms;
using BIMFall4.Manager;
using BIMFall4.Models;
using BIMFall4.Data;
using BIMFall4.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity;
using BIMFall4.Data.Secure;

namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        // GET: api/User/5
        public UserDTO GetSafeUserById(int id)
        {
           return UserManager.GetUserById(id);
        }

        // POST: api/User
        public Response Post([FromBody] User value)
        {
            var form = new UserForm(value);
            var pw = new SecurePassword();

            if (form.isValid())
            {
                pw.SetPassword(value);
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
