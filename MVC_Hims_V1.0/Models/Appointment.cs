using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Hims_V1._0.Models
{
    public class Appointment
    {
        [Key]
        public int OptId { get; set; }
        [Display(Name = "Patient Id")]
        public int PatId { get; set; }
        [Display(Name = "Patient Name")]
        public string  PatName { get; set; }
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }
        [Display(Name = "Appointment")]
        public DateTime OptStart { get; set; }
         
    }
}