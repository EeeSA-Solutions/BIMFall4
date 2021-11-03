using BIMFall4.Data;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Manager.Helper
{
    public class ExpenseRepeater : IRepeater<Expense>
    {
        public List<Expense> CreateOnRepeat(Expense expense)
        {
            List<Expense> newExpenseList = new List<Expense>();

            for (int i = 0; i < 12; i++)
            {
                Expense newExpense = new Expense()
                {
                    Date = expense.Date.AddMonths(i),
                    Name = expense.Name,
                    Category = expense.Category,
                    UserID = expense.UserID,
                    Amount = expense.Amount

                };
                using (var db = new BIMFall4Context())
                {

                    newExpenseList.Add(newExpense);

                }
            }
            return newExpenseList;
        }
    }
}