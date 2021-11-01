using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Web;
using BIMFall4.ModelDTO;
namespace BIMFall4.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public string LastName { get; set; }
        public string Token { get; set; }
        [Index(IsUnique = true), MaxLength(80)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false), MinLength(8)]
        public string Password { get; set; }
        public string Salt { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<SavingGoal> SavingGoals { get; set; }
    }
}