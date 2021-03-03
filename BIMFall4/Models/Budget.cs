using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMFall4.Models
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }
        public DateTime Date { get; set; }
    }
}