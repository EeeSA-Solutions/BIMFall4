using BIMFall4.Authenticator;
using BIMFall4.Manager;
using BIMFall4.Manager.JWTManager;
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
    public class LoginController : ApiController
    {
        TokenManager tokenManager = new TokenManager();
        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        //POST: api/Login
        public Response Post([FromBody] User value)
        {
            User u = new UserRepository().GetUser(value.Email);
            
            if (u.Email != null)
            {
                return LoginManager.GetLoginResponse(value);
            }
            else return null;

        }
        //[HttpPost]
        //public HttpResponseMessage Login(User user)
        //{
        //    User u = new UserRepository().GetUser(user.Email);
        //    if (u == null)
        //        return null;
        //    bool credentials = u.Password.Equals(user.Password);
        //    if (!credentials)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Forbidden,
        //        "The username/password combination was wrong.");
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK,
        //             tokenManager.GenerateToken(user.Email));
        //    }
        //}


        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
