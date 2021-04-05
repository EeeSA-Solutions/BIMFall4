using BIMFall4.Models;
using System.Data.Entity;


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
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<FriendTable>()
            //.HasKey(f => new { f.User, f.Friend } );

            
            modelBuilder.Entity<User>()
                .HasOptional(u => u.Friend)
                .WithMany()
                .HasForeignKey(m => m.ID)
                .WillCascadeOnDelete(false);

            


            
        }
    }
}
