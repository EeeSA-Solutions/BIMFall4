using BIMFall4.Manager;
using BIMFall4.ModelDTO;
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
        public IEnumerable<IncomeDTO> Get(int id)
        {
            return IncomeManager.GetIncomeDtoById(id);
        }

        // POST: api/Income
        public bool Post([FromBody]Income value)
        {

            if(value.Amount > 0)
            {
                IncomeManager.CreateIncome(value);
                return true;
            }
            else
            {
                
                return false;
                
            }
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
