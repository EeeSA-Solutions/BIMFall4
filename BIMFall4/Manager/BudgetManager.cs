using BIMFall4.Data;
using BIMFall4.ModelDTO;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Manager
{
    public class BudgetManager
    {
        public static void CreateBudget(Budget budget)
        {
            using(var db = new BIMFall4Context())
            {
                db.Budgets.Add(budget);
                db.SaveChanges();
            }
        }

        public void DeleteBudget(int id)
        {
            using(var db = new BIMFall4Context())
            {
                if (db.Budgets.Find(id) != null)
                {
                    db.Budgets.Remove(db.Budgets.Find(id));
                    db.SaveChanges();
                }
            }
        }

        public static IEnumerable<Budget> GetBudgetList()
        {
            using (var db = new BIMFall4Context())
            {
                return db.Budgets.ToList();
            }
        }


        public static IEnumerable<Budget> GetBudgetById(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var budget = db.Budgets.Where(x => x.UserID == id).ToList();
                return budget;
            }
        }

        public static IEnumerable<BudgetDTO> GetBudgetDtoById(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var bud = db.Budgets.Where(x => x.UserID == id).ToList();

                var budgetlist = new List<BudgetDTO>();

                foreach (var item in bud)
                {
                    budgetlist.Add(new BudgetDTO
                    {
                        Category = item.Category,
                        Amount = item.Amount,
                        Date = item.Date


                    });

                }

                return budgetlist;
            }
        }
    }
}