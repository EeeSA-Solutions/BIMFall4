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
        public void Put(int id, [FromBody] SavingGoal value)
        {
            SavingGoalManager.EditSavingGoalByID(value, id);
        }

        // DELETE: api/SavingGoal/5
        public void Delete(int id)
        {
            SavingGoalManager.DeleteSavingGoal(id);
        }
    }
}
