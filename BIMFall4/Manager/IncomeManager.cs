using BIMFall4.Data;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Manager
{
    public class IncomeManager
    {
        public void CreateIncome(Income income)
        {
            using (BIMFall4Context db = new BIMFall4Context())
            {
                db.Incomes.Add(income);
                db.SaveChanges();
            }
        }

        public void DeleteIncome(int id)
        {
            using (BIMFall4Context db = new BIMFall4Context())
            {
                if (db.Incomes.Find(id) != null)
                {
                    db.Incomes.Remove(db.Incomes.Find(id));
                    db.SaveChanges();
                }
            }
        }

        public Income GetIncomeById(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var income = db.Incomes.Find(id);
                return income;
            }
        }
    }
}