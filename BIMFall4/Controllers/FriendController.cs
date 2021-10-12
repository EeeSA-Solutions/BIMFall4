using BIMFall4.Authenticator;
using BIMFall4.Manager;
using BIMFall4.ModelDTO;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;


namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]

    public class FriendController : ApiController
    {
        TokenManager tokenManager = new TokenManager();
        // GET: api/Friend
        public IEnumerable<FriendDTO> Get()
        {
            string userid = tokenManager.ValidateToken(Request.Headers.Authorization.Parameter);
            if (userid != null)
            {
                return FriendManager.GetPending(Convert.ToInt32(userid));
            }
            else
            {
                return null;
            }
        }

        // GET: api/Friend/id


        // POST: api/Friend
        public void Post([FromBody] User value)
        {
            string userid = tokenManager.ValidateToken(Request.Headers.Authorization.Parameter);
            if (userid != null && value.ID.ToString()==userid)
            {
            FriendManager.AddFriend(value);
            }
        }

        // PUT: api/Friend/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Friend/5
        public void Delete(int id)
        {
        }
    }
}
