using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMFall4.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool Repeat { get; set; }
        public DateTime Month { get; set; }
        
        public virtual ICollection<BudgetCategory> BudgetCategories{ get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}