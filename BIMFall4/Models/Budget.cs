using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BIMFall4.Models
{
    public class Budget
    {
        [Key]

        public int BudgetID { get; set; }
        public decimal Fixedcost { get; set; }
        public decimal Groceries { get; set; }
        public decimal Entertainment { get; set; }
        public decimal Other { get; set; }

        public virtual User User { get; set; }
    }
}