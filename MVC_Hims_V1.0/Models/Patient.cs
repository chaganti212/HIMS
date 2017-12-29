using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Hims_V1._0.Models
{
    public class Patient
    {
        [Key]
        public int PatId { get; set; }

        [Display(Name = "Name")]
        public string PName { get; set; }

        [Display(Name = "Address")]
        public string PAddress { get; set; }

        [Display(Name = "Phone Number")]
        public string PPhone { get; set; }

        [Display(Name = "Email")]
        public string PEmail { get; set; }

        [Display(Name = "Gender")]
        public string PGender { get; set; }

        public int PDignosisNum { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime PDob { get; set; }

        public int StaffId { get; set; }
        public int DoctorId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}