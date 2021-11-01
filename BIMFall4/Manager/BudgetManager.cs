using BIMFall4.Data;
using BIMFall4.Manager.Helper;
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
        private IRepeater<Budget> repeater;
        public void CreateBudget(Budget budget)
        {
            
            using(var db = new BIMFall4Context())
            {
                if (budget.Repeat)
                {

                    db.Budgets.AddRange(repeater.CreateOnRepeat(budget));
                    db.SaveChanges();
                }
                else
                {
                    var foundDuplicate = db.Budgets.Where(x => x.Date == budget.Date && x.Category == budget.Category).FirstOrDefault();
                    if (foundDuplicate == null)
                    {
                    db.Budgets.Add(budget);
                    db.SaveChanges();

                    }

                }
            }
        }

  

        public static void DeleteBudget(int budgetid, int userid)
        {
            using(var db = new BIMFall4Context())
            {
                var budget = db.Budgets.Find(budgetid);
                if (budget != null && budget.UserID == userid)
                {
                    db.Budgets.Remove(db.Budgets.Find(budgetid));
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
                        ID = item.ID,
                        Category = item.Category,
                        Amount = item.Amount,
                        Date = item.Date
                    });

                }

                return budgetlist;
            }
        }

        public static void EditBudgetByID(Budget budget)
        {
            using (var db = new BIMFall4Context())
            {
                var db_bud = db.Budgets.Where(x => x.ID == budget.ID).FirstOrDefault();
                var foundDuplicate = db.Budgets.Where(x => x.Date.Year == budget.Date.Year 
                && x.Date.Month == budget.Date.Month
                && x.Category == budget.Category).FirstOrDefault();

                if (db_bud != null && foundDuplicate == null)
                {
                    db_bud.Category = budget.Category;
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