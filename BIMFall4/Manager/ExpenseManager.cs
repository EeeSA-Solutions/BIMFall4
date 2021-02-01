using BIMFall4.Data;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Manager
{
    public static class ExpenseManager
    {
        public static void CreateExpense(Expense expense)
        {
            using (var db = new BIMFall4Context())
            {
                db.Expenses.Add(expense);
                db.SaveChanges();
            }
        }

        public static void DeleteExpense(int id)
        {
            using (var db = new BIMFall4Context())
            {
                if (db.Expenses.Find(id) != null)
                {
                    db.Expenses.Remove(db.Expenses.Find(id));
                    db.SaveChanges();
                }
            }
        }

        public static Expense GetExpensesById(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var expense = db.Expenses.Find(id);
                return expense;
            }
        }

        public static IEnumerable<Expense> GetExpenseList(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var expenselist = db.Expenses.Where(expense => expense.UserID == id).ToList();
                return expenselist;
            }

        }


    }
}