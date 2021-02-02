using BIMFall4.Data;
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

        public Budget GetBudgetById(int id)
        {
            using(var db = new BIMFall4Context())
            {
                var budget = db.Budgets.Find(id);
                return budget;
            }
        }
        public static IEnumerable<Budget> GetBudgetList()
        {
            using (var db = new BIMFall4Context())
            {
                return db.Budgets.ToList();
            }
        }
    }
}