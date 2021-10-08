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


        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<SavingGoal> SavingGoals { get; set; }
    }
}
//1. så en reject = delete action på pending.  <--PRIO
//2. accept = en delete i pending men som tar ID och skapar en ny(kopia) relation i tabelen Friends. <---PRIO
//3. block? if /where sats som kollar id på sender och blockar den om den finns med i en block tabell?   
//4. knappar vid pending accept - reject - block?
//5. ska man kunna skicka flera invites till samma perosn samtidigt? 