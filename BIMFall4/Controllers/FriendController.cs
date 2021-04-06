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

    public class FriendController : ApiController
    {

        // GET: api/Friend
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Friend/id
        //public IEnumerable<Friend> Get(int id)
        //{
        //    return FriendManager.GetPending(id);
        //}

        // POST: api/Friend
        public void Post([FromBody] User value)
        {
            //FriendManager.AddFriend(value);
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
