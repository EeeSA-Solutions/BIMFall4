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

        public int Id { get; set; }
        public int From_ID { get; set; }
        public string Email { get; set; }
        public int To_ID { get; set; }
        public string Status { get; set; }

    }
}