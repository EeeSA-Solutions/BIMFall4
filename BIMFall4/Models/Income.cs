using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMFall4.Models
{
    public class Income
    {
        
        [Key]
        public int IncomeID { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public string IncomeName { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public decimal IncomeAmount { get; set; }
       
        public DateTime TransactionDate { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}