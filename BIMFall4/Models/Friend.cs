using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMFall4.Models
{
    public class Friend
    {
        [Key]
        public int Relationship_ID { get; set; }

        public int User1_ID { get; set; }
        public int User2_ID { get; set; }
        [ForeignKey("User1_ID")]
        public virtual User User1 { get; set; }
        [ForeignKey("User2_ID")]
        public virtual User User2 { get; set; }

        public FriendStatus Status { get; set; }

    }
    public enum FriendStatus
    {
        Pending, Accepted, Denied, Blocked
    }
}