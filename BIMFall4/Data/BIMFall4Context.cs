using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BIMFall4.Models;


namespace BIMFall4.Data
{
    public class BIMFall4Context : DbContext
    {
        public BIMFall4Context() : base("name=BudgetImpossibleManagerConnectionsString")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<SavingGoal> SavingGoals { get; set; }
    }
}