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
       public struct Erik
        {
            string Category;
            int Count;
            decimal Amount;
            
            public Erik(string category, int count, decimal amount)
            {
                Category = category;
                Count = count;
                Amount = amount;
            }


        }
        public static List<Erik> Calculate(int userId)
        {
            var list = ExpenseManager.GetUserExpenseDtoSortedByCategoryAndCurrentMonth(userId);
            var sortedlist=list.GroupBy(item=>item.Category)
            .Select(item => new  Erik
                           (
                               item.Key,
                               item.Count(),
                               item.Sum(ta => ta.Amount)
                           )).ToList();

            return sortedlist;
        } 

    }
}