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
                Count = count;
                Amount = amount;
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

    }
}