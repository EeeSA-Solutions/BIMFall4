using BIMFall4.Models;
using System.Data.Entity;


namespace BIMFall4.Data
{
    public class BIMFall4Context : DbContext
    {
        public BIMFall4Context() : base("name=BudgetImpossibleManagerConnectionsString")
        {

        }

        public DbSet<Pending> Pendings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<SavingGoal> SavingGoals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
         .HasMany(p => p.Pendings)
         .WithMany()
         .Map(m => {
       m.MapLeftKey("From_ID");
       m.MapRightKey("To_ID");
       m.ToTable("Related_Pending");
   });
        }
    }
}
