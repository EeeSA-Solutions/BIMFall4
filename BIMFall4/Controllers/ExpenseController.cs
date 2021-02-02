﻿using BIMFall4.Data;
using BIMFall4.Manager;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

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
        public IEnumerable<Expense> Get(int id)
        {
            return ExpenseManager.GetExpensesById(id);
        }

        // POST: api/Expense
        public string Post([FromBody]Expense value)
        {
            ExpenseManager.CreateExpense(value);
            return "det gick bra";
        }

        // PUT: api/Expense/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Expense/5
        public void Delete(int id)
        {
        }
    }
}