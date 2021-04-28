using BIMFall4.Data;
using BIMFall4.Manager;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using BIMFall4.ModelDTO;

namespace BIMFall4.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExpenseController : ApiController
    {
     
        // GET: api/Expense
        public IEnumerable<Expense> Get()
        {
            return ExpenseManager.GetExpenseList();
        }

        // GET: api/Expense/5
        public IEnumerable<ExpenseDTO> Get(int id)
        {
            return ExpenseManager.GetExpenseDtoById(id);
        }

        // POST: api/Expense
        public bool Post([FromBody]Expense value)
        {
            if(value.Amount > 0)
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
        public void Put(int id, [FromBody] Expense value)
        {
            ExpenseManager.PutByID(value, id);
        }

        // DELETE: api/Expense/5

        public void Delete(int id)
        {
            ExpenseManager.DeleteExpense(id);
        }
    }
}
