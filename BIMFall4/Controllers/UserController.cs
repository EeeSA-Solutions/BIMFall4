using BIMFall4.Authenticator;
using BIMFall4.Forms;
using BIMFall4.Manager;
using BIMFall4.ModelDTO;
using BIMFall4.Models;
using System;
using System.Web.Http;

namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        TokenManager tokenManager = new TokenManager();
        // GET: api/User/5
        public UserDTO GetSafeUserById()
        {
            string userid = tokenManager.ValidateToken(Request.Headers.Authorization.Parameter);
            if (userid != null)
            {
                return UserManager.GetUserById(Convert.ToInt32(userid));
            }
            else
            {
                return null;
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
