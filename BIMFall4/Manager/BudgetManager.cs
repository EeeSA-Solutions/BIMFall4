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

        public static void DeleteBudget(int id)
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
                        ID = item.ID,
                        Amount = item.Amount,
                        Date = item.Date
                    });

                }

                return budgetlist;
            }
        }

        public static void EditBudgetByID(Budget budget, int id)
        {
            using (var db = new BIMFall4Context())
            {
                var db_bud = db.Budgets.Where(x => x.ID == id).FirstOrDefault();
                if (db_bud != null)
                {
                    db_bud.Amount = budget.Amount;
                    db_bud.Date = budget.Date;
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