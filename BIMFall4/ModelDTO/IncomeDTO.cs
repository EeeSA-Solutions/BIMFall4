using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.ModelDTO
{
    public class IncomeDTO
    {    
        public string IncomeName { get; set; }
        public decimal IncomeAmount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}