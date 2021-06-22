using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMFall4.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Repeat { get; set; }
        public DateTime Month { get; set; }
        [ForeignKey("Budget")]
        public int BudgetID { get; set; }
        public virtual Budget Budget { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}