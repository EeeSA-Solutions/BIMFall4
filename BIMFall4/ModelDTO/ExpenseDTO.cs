using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.ModelDTO
{
    public class ExpenseDTO
    {
        
        public string Name { get; set; }
        public string Category { get; set; } 
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int ID { get; set; }
    }
}