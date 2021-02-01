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
    public class IncomeController : ApiController
    {
        // GET: api/Income
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Income/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Income
        public void Post([FromBody]Income value)
        {
            IncomeManager obj = new IncomeManager();
            obj.CreateIncome(value);
        }

        // PUT: api/Income/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Income/5
        public void Delete(int id)
        {
        }
    }
}
