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
        ///         Sortera efter månad och år.
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
        public static List<List<ProgressDTO>> Calculate(int userId, DateTime date)
        {
            var expList = ExpenseManager.GetUserExpenseDtoSortedByCategoryAndCurrentDate(userId, date);
            var budList = BudgetManager.GetUserBudgetDtoSortedByCategoryAndCurrentDate(userId, date);

            var groupedExpList = expList.GroupBy(item => item.Category)
            .Select(item => new ProgressDTO
                           (
                               item.Key,
                               item.Count(),
                               item.Sum(ta => ta.Amount)
                           )).ToList();
            var groupedBudList = budList.GroupBy(item => item.Category)
            .Select(item => new ProgressDTO
                           (
                               item.Key,
                               item.Count(), // kan kommas att ta bort då tanken är att inte kunna ha fler än en budget av varje typ.
                               item.Sum(ta => ta.Amount) // när ovan blir aktuellt behöver vi ej summera heller.
                           )).ToList();

            List<List<ProgressDTO>> expBudList = new List<List<ProgressDTO>> { groupedExpList, groupedBudList };

            return expBudList;
        }
    }
}