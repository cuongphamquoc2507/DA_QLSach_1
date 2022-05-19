using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DA_QLSach.Models
{
    public class login
    {
        [Key]
        [Display(Name = "Email")]
        public string userMail { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}