using BIMFall4.Data;
using BIMFall4.Manager.Helper;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Manager.Repeat
{
    public class IncomeRepeater : IRepeater<Income>
    {
        public List<Income> CreateOnRepeat(Income income)
        {
            List<Income> newIncomeList = new List<Income>();

            for (int i = 0; i < 12; i++)
            {
                Income newIncome = new Income()
                {
                    Name = income.Name,
                    Amount = income.Amount,
                    Date = income.Date.AddMonths(i),
                    UserID = income.UserID

                };
                using (var db = new BIMFall4Context())
                {
                        newIncomeList.Add(newIncome);
                }
            }
            return newIncomeList;
        }
    }
}