using BIMFall4.Authenticator;
using BIMFall4.Manager;
using BIMFall4.ModelDTO;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            var req = Request;
            var request = new HttpRequestMessage();
            var x = request.Headers.Date;
            if(Request.Headers.Date != null)
            {
                var currentDate = Request.Headers.Date;
            }
            string userid = tokenManager.ValidateToken(Request);
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
            string userid = tokenManager.ValidateToken(Request);
            
            if (userid != null && value.Amount > 0 && value.UserID == Convert.ToInt32(userid))
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

        public void Put([FromBody] Expense value)
        {
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null && value.Amount > 0 && value.UserID == Convert.ToInt32(userid))
            {
                ExpenseManager.EditExpenseByID(value);
            }
            else
            {
                return;
            }
        }

        // DELETE: api/Expense/5


        public void Delete([FromBody] string expenseId)
        {
            string userid = tokenManager.ValidateToken(Request);
            if (userid != null)
            {
                ExpenseManager.DeleteExpense(Convert.ToInt32(expenseId), Convert.ToInt32(userid));
            }
        }
    }
}
