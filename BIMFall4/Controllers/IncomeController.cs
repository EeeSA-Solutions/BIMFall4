using BIMFall4.Authenticator;
using BIMFall4.Manager;
using BIMFall4.ModelDTO;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class IncomeController : ApiController
    {
        TokenManager tokenManager = new TokenManager();
        // GET: api/Income

        public IEnumerable<IncomeDTO> Get()
        {
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null)
            {
                return IncomeManager.GetIncomeDtoById(Convert.ToInt32(userid));
            }
            else
            {
                return null;
            }


        }
        // GET: api/Income/5

        // POST: api/Income
        public bool Post([FromBody] Income value)
        {
            string userid = tokenManager.ValidateToken(Request);

            if (userid != null && value.Amount > 0 && value.UserID.ToString() == userid)

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

        public void Put([FromBody]Income value)
        {
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null && value.Amount > 0 && value.UserID == Convert.ToInt32(userid))
            {
                IncomeManager.EditIncomeByID(value);
            }
            else
            {
                return;
            }
        }

        // DELETE: api/Income/5
        public void Delete([FromBody] string incomeId)
        {
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null)
            {
                IncomeManager.DeleteIncome(Convert.ToInt32(incomeId), Convert.ToInt32(userid));
            }
        }
    }
}
