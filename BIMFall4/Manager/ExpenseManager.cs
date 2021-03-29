using BIMFall4.Data;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BIMFall4.ModelDTO;

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

        public static IEnumerable<Expense> GetExpensesById(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var expense = db.Expenses.Where(x => x.UserID == id).ToList();
                return expense;
            }
        }

        public static IEnumerable<Expense> GetExpenseList()
        {
            using (var db = new BIMFall4Context())
            {
                return db.Expenses.ToList();
            }
        }


        public static IEnumerable<ExpenseDTO> GetExpenseDtoById(int id)
        {
            using(var db = new BIMFall4Context())
            {
                var exp = db.Expenses.Where(x => x.UserID == id).ToList();

                var expenselist = new List<ExpenseDTO>();

                foreach (var item in exp)
                {
                    expenselist.Add(new ExpenseDTO
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Category = item.Category,
                        Date = item.Date,
                        Amount = item.Amount


                    });
                   
                }

                return expenselist;
            }
        }
    }
}