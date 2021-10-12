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
    public class ExpenseController : ApiController
    {
        TokenManager tokenManager = new TokenManager();
        // GET: api/Expense/5

        public IEnumerable<ExpenseDTO> Get()
        {
            string userid = tokenManager.ValidateToken(Request.Headers.Authorization.Parameter);
            if (userid != null)
            {
                return ExpenseManager.GetExpenseDtoById(Convert.ToInt32(userid));
            }
            else
            {
                return null;
            }
        }

        // POST: api/Expense
        public bool Post([FromBody] Expense value)
        {
            string userid = tokenManager.ValidateToken(Request.Headers.Authorization.Parameter);
            value.UserID = Convert.ToInt32(userid);
            if (userid != null && value.Amount > 0)
            {
                ExpenseManager.CreateExpense(value);
                return true;
            }
            else
            {
                return false;
            }
        }

        // PUT: api/Expense/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Expense/5

        public void Delete(int id)
        {
            ExpenseManager.DeleteExpense(id);
        }
    }
}
