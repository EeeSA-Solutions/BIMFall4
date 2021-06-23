using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMFall4.Models
{
    public class BudgetCategory
    {
       
        [Key, Column(Order=0)]
        public int BudgetID { get; set; }
        [Key, Column(Order = 1)]
        public int CategoryID { get; set; }

        public int MaxAmount { get; set; }

        public virtual Budget Budget { get; set; }
        public virtual Category Category { get; set; }
    }
}