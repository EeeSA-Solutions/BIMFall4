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
    public class BudgetController : ApiController
    {
        // GET: api/Budget
        public IEnumerable<Budget> Get()
        {
            return BudgetManager.GetBudgetList();
        }

        // GET: api/Budget/5
        public IEnumerable<BudgetDTO> Get(int id)
        {
            return BudgetManager.GetBudgetDtoById(id);
        }

        // POST: api/Budget
        public void Post([FromBody]Budget value)
        {
            BudgetManager.CreateBudget(value);

        }

        // PUT: api/Budget/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Budget/5
        public void Delete(int id)
        {
        }
    }
}
