namespace BIMFall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        BudgetId = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BudgetId)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 80),
                        LastName = c.String(nullable: false, maxLength: 80),
                        Email = c.String(maxLength: 80),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseID = c.Int(nullable: false, identity: true),
                        ExpenseName = c.String(nullable: false, maxLength: 80),
                        Category = c.String(),
                        TransactionDate = c.DateTime(nullable: false),
                        ExpenseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        IncomeID = c.Int(nullable: false, identity: true),
                        IncomeName = c.String(nullable: false, maxLength: 80),
                        IncomeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionDate = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IncomeID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.SavingGoals",
                c => new
                    {
                        SavingGoalID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        ReachDate = c.DateTime(nullable: false),
                        GoalName = c.String(nullable: false, maxLength: 80),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SavingGoalID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Budgets", "UserID", "dbo.Users");
            DropForeignKey("dbo.SavingGoals", "UserID", "dbo.Users");
            DropForeignKey("dbo.Incomes", "UserID", "dbo.Users");
            DropForeignKey("dbo.Expenses", "UserID", "dbo.Users");
            DropIndex("dbo.SavingGoals", new[] { "UserID" });
            DropIndex("dbo.Incomes", new[] { "UserID" });
            DropIndex("dbo.Expenses", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Budgets", new[] { "UserID" });
            DropTable("dbo.SavingGoals");
            DropTable("dbo.Incomes");
            DropTable("dbo.Expenses");
            DropTable("dbo.Users");
            DropTable("dbo.Budgets");
        }
    }
}
