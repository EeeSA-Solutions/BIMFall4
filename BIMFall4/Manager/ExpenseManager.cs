using BIMFall4.Data;
using BIMFall4.ModelDTO;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        //EE tog bort getExpById och getListExp.

       
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

        public static IEnumerable<ExpenseDTO> GetUserExpenseDtoSortedByCategoryAndCurrentDate( int userId, DateTime date)
        {
            using (var db = new BIMFall4Context())
            {
                var exp = db.Expenses.Where(x => x.UserID == userId && x.Date.Month == date.Month && x.Date.Year == date.Year).ToList();

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