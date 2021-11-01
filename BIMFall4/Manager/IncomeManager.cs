using BIMFall4.Data;
using BIMFall4.ModelDTO;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Manager
{
    public class IncomeManager
    {
        public static void CreateIncome(Income income)
        {
                using (BIMFall4Context db = new BIMFall4Context())
                {
                    db.Incomes.Add(income);
                    db.SaveChanges();
                }
        }

        public static void DeleteIncome(int incomeId, int userid )
        {
            using (var db = new BIMFall4Context())
            {
                var income = db.Incomes.Find(incomeId);
                if (income != null && income.UserID == userid)
                {
                    db.Incomes.Remove(db.Incomes.Find(incomeId));
                    db.SaveChanges();
                }
            }
        }

        public static IEnumerable<IncomeDTO> GetIncomeDtoById(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var inc = db.Incomes.Where(x => x.UserID == id).ToList();

                var incomelist = new List<IncomeDTO>();

                foreach (var item in inc)
                {
                    incomelist.Add(new IncomeDTO
                    {
                        ID = item.ID,
                        Amount = item.Amount,
                        Name = item.Name,
                        Date = item.Date
                    });
                }
                return incomelist;
            }
        }

        public static void EditIncomeByID(Income income)
        {
            using (var db = new BIMFall4Context())
            {
                var inc = db.Incomes.Where(x => x.ID == income.ID).FirstOrDefault();
                if(inc != null)
                {
                    inc.Name = income.Name;
                    inc.Amount = income.Amount;
                    inc.Date = income.Date;
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