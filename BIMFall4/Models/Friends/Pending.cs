using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BIMFall4.Models;
namespace BIMFall4.Models
{
    public class Pending
    {
        [Key]
        [Column(Order = 1)]
        public int From_ID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int To_ID { get; set; }

        [ForeignKey("From_ID")]
        
        public User ID { get; set; }

        [ForeignKey("To_ID")]
        
        public User Friend_ID { get; set; }

        [NotMapped]
        public string To_Email { get; set; }
    }
}


//1. så en reject = delete action på pending.  <--PRIO
//2. accept = en delete i pending men som tar ID och skapar en ny(kopia) relation i tabelen Friends. <---PRIO
//3. block? if /where sats som kollar id på sender och blockar den om den finns med i en block tabell?   
//4. knappar vid pending accept - reject - block?
//5. ska man kunna skicka flera invites till samma perosn samtidigt? 