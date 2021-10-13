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

        public static void EditExpenseByID(Expense expense, int id)
        {
            using (var db = new BIMFall4Context())
            {
                var db_exp = db.Expenses.Where(x => x.ID == id).FirstOrDefault();
                if (db_exp != null)
                {
                    db_exp.Category = expense.Category;
                    db_exp.Amount = expense.Amount;
                    db_exp.Date = expense.Date;
                    db_exp.Name = expense.Name;
                }
                else
                {
                    return;
                }
                db.SaveChanges();
            }
        }
    }
}