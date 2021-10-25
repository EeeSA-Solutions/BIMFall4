using BIMFall4.Manager.CalculateManagers;
using BIMFall4.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BIMFall4.Controllers
{
    public class CalculateController : ApiController
    {
        // GET: api/Calculate
        public List<ProgressCalculations.ProgressDTO> Get()
        {
            return ProgressCalculations.Calculate(1);
            
        }

        // GET: api/Calculate/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Calculate
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Calculate/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Calculate/5
        public void Delete(int id)
        {
        }
    }
}
