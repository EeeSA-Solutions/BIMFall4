using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.ModelDTO
{
    public class SavingGoalDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime ReachDate { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}