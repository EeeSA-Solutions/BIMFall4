using BIMFall4.Data;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BIMFall4.ModelDTO;
using BIMFall4.Manager.Helper;

namespace BIMFall4.Manager
{
    public class ExpenseManager
    {
        public void CreateExpense(Expense expense)
        {
            IRepeater<Expense> repeater = new ExpenseRepeater();
            using (var db = new BIMFall4Context())
            {
                if (expense.Repeat)
                {
                    db.Expenses.AddRange(repeater.CreateOnRepeat(expense));
                    db.SaveChanges();
                }
                else
                {
                    db.Expenses.Add(expense);
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteExpense(int expenseId, int userid)
        {
            using (var db = new BIMFall4Context())
            {
                var expense = db.Expenses.Find(expenseId);
                if (expense != null && expense.UserID == userid)
                {
                    db.Expenses.Remove(db.Expenses.Find(expenseId));
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
            using (var db = new BIMFall4Context())
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

        public static void EditExpenseByID(Expense expense)
        {
            using (var db = new BIMFall4Context())
            {
                var db_exp = db.Expenses.Where(x => x.ID == expense.ID).FirstOrDefault();
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