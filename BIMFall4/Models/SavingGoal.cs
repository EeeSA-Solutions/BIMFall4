using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BIMFall4.Models
{
    public class SavingGoal
    {
        [Key]
        public int SavingGoalID { set; get; }
        public DateTime StartDate { get; set; }
        public DateTime ReachDate { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public string GoalName { get; set; }
        public decimal Amount { get; set; }

        public virtual User User { get; set; }
    }
}