using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BIMFall4.Models;
namespace BIMFall4.Models
{
    public class Pending
    {
        [Key]
        public int From_ID { get; set; }
        public int To_ID { get; set; }

        [ForeignKey("From_ID")]
        [Column(Order = 1)]
       [ConcurrencyCheck]
        public User ID { get; set; }

        [ForeignKey("To_ID")]
        [Column(Order = 2)]
        [ConcurrencyCheck]
        public User User_ID { get; set; }

    }
}