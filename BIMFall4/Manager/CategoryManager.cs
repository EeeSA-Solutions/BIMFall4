using BIMFall4.Data;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BIMFall4.Manager
{
    public class CategoryManager
    {
        public static void CreateCategory(Category category)
        {
            using(var db = new BIMFall4Context())
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }
        public static void DeleteCategory(int categoryID, int budgetID)
        {
            using(var db = new BIMFall4Context())
            {
           
                //expenses that belongs to the category
                var expenses = db.Expenses.Where(x => x.CategoryID == categoryID).ToList();
                if (expenses != null)
                {
                    //get the "Other" category
                    var category = db.Categories.Where(x => x.Name.Equals("Other")
                    && x.Month.Equals(DateTime.Now.ToString("MM yyyy"))).Include(y => y.ID == categoryID).FirstOrDefault();
                    //&& x.BudgetID == budgetID).FirstOrDefault();
                       
                        //&& db.Users.Where(x => x.ID == userID).FirstOrDefault();

                        foreach (var expense in expenses)
                    {
                        expense.CategoryID = category.ID;
                    }
                }
                if (db.Categories.Find(categoryID) != null)
                {
                    db.Categories.Remove(db.Categories.Find(categoryID));
                    db.SaveChanges();
                }
            }
        }
        static public IEnumerable<Category> GetCategoryByBudegetId(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var categories = db.Categories.Where(x => x.BudgetID == id).Include(x => x.Expenses).ToList();
                return categories;
            }
        }
    }
}