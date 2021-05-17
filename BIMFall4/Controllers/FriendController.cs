﻿using BIMFall4.Manager;
using BIMFall4.ModelDTO;
using BIMFall4.Models;
using System.Collections.Generic;
using System.Web.Http;


namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    
    public class FriendController : ApiController
    {

        // GET: api/Friend
        
        // GET: api/Friend/id
        public IEnumerable<FriendDTO> Get(int id)
        {
            return FriendManager.GetPendingSentFriendsList(id);
        }
        // POST: api/Friend
        public Response Post([FromBody] User value)
        {
            return FriendManager.AddFriend(value);
        }

        //PUT: api/Friend/id/wantedstatus
        public Response Put(int id, [FromBody] FriendStatus value)
        {
            return FriendManager.SetFriendStatus(id, value);
        }

        // DELETE: api/Friend/5
        public void Delete(int id)
        {
            FriendManager.DeleteRelationship(id);
        }
    }
}
