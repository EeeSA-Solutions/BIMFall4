using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMFall4.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseID { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(80)] // tillåter inte en tom sträng. max 80 char.
        public string ExpenseName { get; set; }

        public string Category { get; set; } //Val av katogorinamn
        public DateTime TransactionDate { get; set; }
        public decimal ExpenseAmount { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }
        
    }
}