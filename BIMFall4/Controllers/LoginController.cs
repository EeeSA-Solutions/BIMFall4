using BIMFall4.Manager;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        // GET: api/Login
        public IHttpActionResult Get()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var Email = identity.Claims
                     .FirstOrDefault(c => c.Type == "Email").Value;
            var UserName = identity.Name;
            return Ok("Hello: " + UserName + ", your email is: " + Email);
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }
            
        // POST: api/Login
        public Response Post([FromBody] User value)
        {
            return LoginManager.GetLoginResponse(value);
        }


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
