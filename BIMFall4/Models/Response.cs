using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMFall4.Models
{
    public class Response
    {
        public string Status { set; get; }
        public string Message { set; get; }
        public int UserID { get; set; }
    }
}