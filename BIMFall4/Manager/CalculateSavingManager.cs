using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BIMFall4.Manager;
using BIMFall4.Models;

namespace BIMFall4.Manager
{
    public class CalculateSavingManager 
    {   
         public static IEnumerable<Budget> CheckMonthOfBudget(int id)
        {
            DateTime today = DateTime.Now;
            int month = today.Month;
            int year = today.Year;

            var budgets = BudgetManager.GetBudgetById(id);
            //var filteredBudgets = budgets.Where(x => x.StartMonth < x.StartMonth.AddMonths(1).AddDays(-1)).ToList();
            var filteredBudgets = budgets.Where(x => x.StartMonth.Month < month).ToList();
            return filteredBudgets;

        }
        public static void TransferBudget(int id, string goalName)
        {
            var filteredBudget = CheckMonthOfBudget(id);


        }
        
    }
}