using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BIMFall4.Manager;
using BIMFall4.ModelDTO;
using BIMFall4.Models;

namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SavingGoalController : ApiController
    {
        // GET: api/SavingGoal
        public IEnumerable<SavingGoal> Get()
        {
            return SavingGoalManager.GetSavingGoalList();
        }

        // GET: api/SavingGoal/5
        public IEnumerable<SavingGoalDTO> Get(int id)
        {
            return SavingGoalManager.GetSavingGoalDtoById(id);
        }

        // POST: api/SavingGoal
        public bool Post([FromBody]SavingGoal value)
        {
            if(value.Amount > 0)
            {
                SavingGoalManager.CreateSavingGoal(value);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        // PUT: api/SavingGoal/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SavingGoal/5
        public void Delete(int id)
        {
            SavingGoalManager.DeleteSavingGoal(id);
        }
    }
}
