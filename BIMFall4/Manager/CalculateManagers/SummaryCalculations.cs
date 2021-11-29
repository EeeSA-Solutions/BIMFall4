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
        public static void RemainLoop(List<ProgressDTO> list1, List<ProgressDTO> list2)
        {
                foreach (ProgressDTO element1 in list1)
                {
                    foreach (ProgressDTO element2 in list2)
                    {
                        if (element1.Category == element2.Category)
                        {
                            var remain = element2.Amount - element1.Amount;
                            Remaining.Add(new ProgressDTO(Exp.Category, remain));
                        }
                    }
                }
        }
        public static ProgressDTO SummaryCalc(int userId, DateTime date)
        {
            var calcList = Calculate(userId, date);

            if (calcList[0].Count > calcList[1].Count)
            {
                RemainLoop(calcList[0], calcList[1]);
            }
            else
            {
                RemainLoop(calcList[1], calcList[0]);
            }

        }
    }
}