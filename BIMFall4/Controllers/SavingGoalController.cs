using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BIMFall4.Controllers
{
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
        public void Post([FromBody]string value)
        {
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
