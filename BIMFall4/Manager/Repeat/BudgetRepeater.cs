using BIMFall4.Data;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Manager.Helper
{
    public class BudgetRepeater : IRepeater<Budget>
    {
        public List<Budget> CreateOnRepeat(Budget budget)
        {
            List<Budget> newbudgetlist = new List<Budget>();

            for (int i = 0; i < 12; i++)
            {
                Budget newbudget = new Budget()
                {
                    Date = budget.Date.AddMonths(i),
                    Category = budget.Category,
                    UserID = budget.UserID,
                    Amount = budget.Amount

                };
                using (var db = new BIMFall4Context())
                {
                    if (db.Budgets.Where(x => x.Date == newbudget.Date && x.Category == newbudget.Category && x.UserID == newbudget.UserID).FirstOrDefault() == null)
                    {
                        newbudgetlist.Add(newbudget);
                    }
                }
            }
            return newbudgetlist;
        }
    }
}