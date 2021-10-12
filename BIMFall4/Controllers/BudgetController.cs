using BIMFall4.Manager;
using BIMFall4.ModelDTO;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BIMFall4.Authenticator;
namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BudgetController : ApiController
    {
        TokenManager tokenManager = new TokenManager();
      
        // GET: api/Budget/5
        public IEnumerable<BudgetDTO> Get()
        {
            string userid = tokenManager.ValidateToken(Request.Headers.Authorization.Parameter);
            if (userid != null)
            {
            return BudgetManager.GetBudgetDtoById(Convert.ToInt32(userid));
            }
            else
            {
                return null;
            }
        }

        // POST: api/Budget
        public bool Post([FromBody] Budget value)
        {
            string userid = tokenManager.ValidateToken(Request.Headers.Authorization.Parameter);
            if (userid != null && value.Amount > 0)
            {
                BudgetManager.CreateBudget(value);
                return true;
            }
            else
            {
                return false;
            }
        }

        // PUT: api/Budget/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Budget/5
        public void Delete(int id)
        {
            BudgetManager.DeleteBudget(id);
        }
    }
}
