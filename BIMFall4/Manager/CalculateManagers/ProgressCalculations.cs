using System.Collections.Generic;
using System.Linq;
using System;

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
            public decimal Amount { get; set; }

            public ProgressDTO(string category, decimal amount)
            {
                Category = category;
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
                               item.Sum(ta => ta.Amount)
                           )).ToList();
            var groupedBudList = budList.GroupBy(item => item.Category)
            .Select(item => new ProgressDTO
                           (
                               item.Key,
                               item.Sum(ta => ta.Amount) // när ovan blir aktuellt behöver vi ej summera heller.
                           )).ToList();

            List<ProgressDTO> Remaining = new List<ProgressDTO>();



          foreach (ProgressDTO Exp in groupedExpList)
            {
                foreach (ProgressDTO Bud in groupedBudList)
                {
                    if (Exp.Category == Bud.Category)
                    {
                        var remain = Bud.Amount - Exp.Amount;
                        Remaining.Add(new ProgressDTO(Exp.Category, remain));
                    }
                }
            }


            List<List<ProgressDTO>> expBudList = new List<List<ProgressDTO>> { groupedExpList, groupedBudList };

            return expBudList;
        }
    }
}

//TODO: Vad händer om expenses är av mindre antal än budget. tex det finns 4 exp men fem budgetar?? vi måste ju ha alla exp och alla budgetar. 