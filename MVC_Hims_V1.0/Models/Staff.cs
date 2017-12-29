using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Hims_V1._0.Models
{
    public class Staff
    {
        [key]
        public int StaffId { get; set; }

        public string StaffRole { get; set; }

        [Display(Name = "Name")]
        public string SName { get; set; }

        public string Qualification { get; set; }

        [Display(Name = "Phone Number")]
        public string SPhone { get; set; }

        [Display(Name = "Gender")]
        public string SGender { get; set; }

        public string SUserId { get; set; }
        public string SPassword { get; set; }
    }
}