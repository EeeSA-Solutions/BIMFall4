using BIMFall4.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BIMFall4.Data
{
    public class BIMFall4Context : DbContext
    {
        public BIMFall4Context() : base("name=BudgetImpossibleManagerConnectionsString")
        {
            //base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<SavingGoal> SavingGoals { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelbuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
