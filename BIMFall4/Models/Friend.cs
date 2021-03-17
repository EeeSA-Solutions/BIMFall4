using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BIMFall4.Models
{
    public class Friend
    {
        [Key]

        public int ID { get; set; }
        public int From_ID { get; set; }
        public string From_Firstname { get; set; }
        public string From_Lastname { get; set; }
        [EmailAddress]
        public string From_Email { get; set; }
        [EmailAddress]
        public string To_Email { get; set; }
        public int To_ID { get; set; }
        public string Status { get; set; }

    }
}