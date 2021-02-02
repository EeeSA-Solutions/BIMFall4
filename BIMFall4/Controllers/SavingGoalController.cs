using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BIMFall4.Manager;
using BIMFall4.Models;

namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SavingGoalController : ApiController
    {
        // GET: api/SavingGoal
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SavingGoal/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SavingGoal
        public void Post([FromBody]SavingGoal value)
        {
            SavingGoalManager.CreateSavingGoal(value);
        }

        // PUT: api/SavingGoal/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SavingGoal/5
        public void Delete(int id)
        {
        }
    }
}
