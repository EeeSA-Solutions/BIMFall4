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

        public virtual User User1 { get; set; }

        public virtual User User2 { get; set; }

        public FriendStatus Status { get; set; }

    }
    public enum FriendStatus
    {
        Pending, Accepted, Blocked
    }
}