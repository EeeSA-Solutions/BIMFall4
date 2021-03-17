using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.ModelDTO
{
    public class ExpenseDTO
    {   
        public string ExpenseName { get; set; }
        public string Category { get; set; } 
        public DateTime TransactionDate { get; set; }
        public decimal ExpenseAmount { get; set; }
    }
}