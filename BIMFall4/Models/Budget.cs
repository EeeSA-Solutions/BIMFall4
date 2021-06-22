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
        public int ID { get; set; }
        
        public decimal Amount { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}