using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BIMFall4.Authenticator;
using BIMFall4.Manager;
using BIMFall4.ModelDTO;
using BIMFall4.Models;

namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SavingGoalController : ApiController
    {

        TokenManager tokenManager = new TokenManager();
        // GET: api/SavingGoal
        public IEnumerable<SavingGoalDTO> Get()
        {
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null)
            {
            return SavingGoalManager.GetSavingGoalDtoById(Convert.ToInt32(userid));
            }
            else
            {
                return null;
            }
        }

        // GET: api/SavingGoal/5

        // POST: api/SavingGoal
        public bool Post([FromBody]SavingGoal value)
        {
            string userid = tokenManager.ValidateToken(Request);

            if (userid != null && value.Amount > 0 && value.UserID.ToString() == userid)
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
        public void Put([FromBody] SavingGoal value)
        {
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null && value.Amount > 0 && value.UserID == Convert.ToInt32(userid))
            {
            SavingGoalManager.EditSavingGoalByID(value);
            }
            else
            {
                return;
            }

        }

        // DELETE: api/SavingGoal/5

        public void Delete([FromBody] string savinggoalId)
        {
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null)
            {
                SavingGoalManager.DeleteSavingGoal(Convert.ToInt32(savinggoalId), Convert.ToInt32(userid));
            }
        }
        
    }
}
