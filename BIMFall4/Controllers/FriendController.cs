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
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null)
            {
                return FriendManager.GetPendingSentFriendsList(Convert.ToInt32(userid));
            }
            else
            {
                return null;
            }
        }

        // GET: api/Friend/id


        // POST: api/Friend
        public Response Post([FromBody] User value)
        {
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null && value.ID.ToString() == userid)
            {
                return FriendManager.AddFriend(value);
            }
            else
            {
                return null;
            }
        }

        //PUT: api/Friend/id
       [HttpPut]
       
        public Response Put(int id,[FromBody] FriendStatus value)
        {
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null)
            {
                return FriendManager.SetFriendStatus(id, value);
            }
            else
            {
                return null;
            }
        }

        // DELETE: api/Friend/
        public void Delete([FromBody] string relId)
        {
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null)
                FriendManager.DeleteRelationship(Convert.ToInt32(relId));
        }
    }
}
