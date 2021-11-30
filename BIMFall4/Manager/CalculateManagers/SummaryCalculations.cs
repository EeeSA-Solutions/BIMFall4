using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Manager.CalculateManagers
{
    public class SummaryCalculations : ProgressCalculations
    {
        /// Vi vill ha alla categories med ett värde ovasett om det finns i DB. tex groceries sätts till 0 om det inte finns en exp under den kategorin.
        /// Vill hålla det loose kopplat. 
        /// Total exp per kat, total bud per kat och kvarstående saldo per kat(bud-exp)
        /// 

        // vi behöver ett interface med metod som skapar en instans. Sen kalla på factory i nästa steg. Kanske lyfta ut logik till egen klass
       
      
        
        public void RemainLoop(List<ProgressDTO> expenses, List<ProgressDTO> budgets)
        {
            
                    foreach (ProgressDTO bud in budgets)
                {
                foreach (ProgressDTO exp in expenses)
                    {
                        if (exp.Category == bud.Category)
                        {
                            var remain = bud.Amount - exp.Amount;

                          //  Remaining.Add(new ProgressDTO(Exp.Category, remain));
                        }
                    }
                }
        }
        public ProgressDTO SummaryCalc(int userId, DateTime date)
        {
            var calcList = Calculate(userId, date);
            var totalExpensesList = calcList[0];
            var totalBudgetList = calcList[1];
          
            
                RemainLoop(totalExpensesList, totalBudgetList);
            
        
            return new ProgressDTO( "ds", 1 ); // ta bort sen
        }
    }
}