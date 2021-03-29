using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BIMFall4.Models
{
    public class Expense
    {
        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(80)] // tillåter inte en tom sträng. max 80 char.
        public string Name { get; set; }

        public string Category { get; set; } 
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        
        public decimal Amount { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }
        
    }
}