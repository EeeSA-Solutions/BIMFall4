using BIMFall4.Data;
using BIMFall4.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BIMFall4.Manager.CalculateManagers
{

    public class ProgressCalculations
    {
        ///  <summary> 
        ///        Hämta budget per enskild kategori och deras expense.
        ///         - Lägg sedan ihop dessa expenses och skicka den summan och budget summan till front(1200/5000)
        ///         Gör sedan en total uträkning för alla expenses och alla budgetar och skicka till front (13000/17000)
        ///         Sortera efter månad.
        ///  </summary>
       public struct ProgressDTO
        {
           public string Category { get; set; }
            public int Count { get; set; }
           public decimal Amount { get; set; }

            public ProgressDTO(string category, int count, decimal amount)
            {
                Category = category;
                Count = count; // Antal element i t.ex Groceries
                Amount = amount; //totala summan
            }
             

        }
        public static List<ProgressDTO> Calculate(int userId)
        {
            var list = ExpenseManager.GetUserExpenseDtoSortedByCategoryAndCurrentMonth(userId);
            var sortedlist=list.GroupBy(item=>item.Category)
            .Select(item => new  ProgressDTO
                           (
                               item.Key,
                               item.Count(),
                               item.Sum(ta => ta.Amount)
                           )).ToList();

            return sortedlist;
        }

        public static IEnumerable<BudgetDTO> GetUserBudgetDtoSortedByCategoryAndCurrentMonth(int userId)
        {
            using (var db = new BIMFall4Context())
            {
                var bud = db.Budgets.Where(x => x.UserID == userId && x.Date.Month == DateTime.Now.Month && x.Date.Year == DateTime.Now.Year).ToList();

                var budgetlist = new List<BudgetDTO>();

                foreach (var item in bud)
                {
                    budgetlist.Add(new BudgetDTO
                    {
                        ID = item.ID,
                        Category = item.Category,
                        Date = item.Date,
                        Amount = item.Amount

                    });
                }
                return budgetlist;
            }
        }

    }
}