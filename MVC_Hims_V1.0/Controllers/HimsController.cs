using MVC_Hims_V1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Data.Entity.SqlServer;

namespace MVC_Hims_V1._0.Controllers
{
    public class HimsController : Controller
    {
        // GET: Hims
        
        private ApplicationDbContext _Context;
        public HimsController()
        {
            _Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        
       
        public ActionResult Index()
        {
            var patients = _Context.Patient.ToList();
            return View("HomeHims");
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Details(string PatorDocDropDown, string UserId, string Password)
        {
            if (PatorDocDropDown == "Patient")
            {
                var patients = _Context.Patient.SingleOrDefault(p => p.UserId == UserId && p.Password == Password);
                Session["userid"] = UserId;
                if (patients == null)
                    return HttpNotFound();
                return View("PatientHome");
            }
            else if (PatorDocDropDown == "Doctor")
            {
                var doctor = _Context.Staff.SingleOrDefault(d => d.SUserId == UserId && d.SPassword == Password);
                Session["userid"] = UserId;
                if (doctor == null)
                    return HttpNotFound();
                return View("DoctorHome", doctor);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult PRegester(Patient viewModel)
        {
            _Context.Patient.Add(viewModel);
            _Context.SaveChanges();
            return View("HomeHims");
        }
        public ActionResult AppointmentDefault()
        {
            
                    var Doc = _Context.Doctor.ToList();
                    var viewModel = new DoctorsViewModel
                    {
                        Doctors = Doc
                    };
                    return View(viewModel);
           
        }
        public ActionResult Timevalue(DateTime EnterDate, string Doctors)
        {
            //DateTime datec = Convert.ToDateTime(EnterDate);
            var Timevalue = _Context.Appointment.Where(i => i.OptStart.Year== EnterDate.Year && i.OptStart.Month == EnterDate.Month && i.OptStart.Day == EnterDate.Day && i.DoctorName == Doctors).Select(i => i.OptStart).ToList();
            List<string> list = new List<string>()
            {
                "09:00","09:30","10:00","10:30","11:00","11:30","12:00","13:30","14:00","14:30","15:00","15:30","16:00","16:30"
            };
            List<string> temp = new List<string>();
            foreach (var t in Timevalue)
            {
                foreach (var l in list)
                {
                    if (l == t.Hour.ToString()+":"+ t.Minute.ToString())
                    {
                        temp.Add(l);
                    }
                }

            }
            foreach(var t in temp)
            {
                list.Remove(t);
            }
            return Json(list);
        }

        public ActionResult Home()
        {
            return View("HomeHims");
        }

        [HttpGet]
        public ActionResult LoginCheck()
        {
            if (Session["userid"] != null)
            {
                return RedirectToAction("AppointmentDefault", "Hims");
            }
            else
            {
                return RedirectToAction("LoginFailed", "Hims");
            }
        }

        public ActionResult LoginFailed()
        {
            return Redirect("~/Account/Login");
        }

        

        public ActionResult SubmitScheduleData(string Doctors, DateTime EnterDate, DateTime SelectedTime)
        {
            string username = Convert.ToString(Session["userid"]);
            string Patientname = _Context.Patient.Where(i => i.UserId == username).Select(i => i.PName).Single();
            int Patid = _Context.Patient.Where(i => i.UserId == username).Select(i => i.PatId).Single();
            var DoctorName2 = Doctors;
            DateTime SelectedDate = EnterDate;
            DateTime SelectedTime1 = SelectedTime;
            DateTime sqldatetime = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, SelectedTime1.Hour, SelectedTime1.Minute, SelectedTime1.Second);

            Appointment App = new Appointment
            {
                OptStart = sqldatetime,
                DoctorName = DoctorName2,
                PatName = Patientname,
                PatId = Patid
            };
            _Context.Appointment.Add(App);
            _Context.SaveChanges();
            return Redirect("HomeHims");
        }

        public ActionResult PatientHome()
        {
            return View("PatientHome");
        }

        public PartialViewResult Patienthistory()
        {
            string username = Convert.ToString(Session["userid"]);
            string Patientname = _Context.Patient.Where(i => i.UserId == username).Select(i => i.PName).Single();
            var list = _Context.Appointment.Where(i => i.PatName == Patientname).Select(i => new { i.DoctorName, i.OptStart }).OrderByDescending(i => i.OptStart).ToList();
            List<Appointment> appnmnts = new List<Appointment>();
            foreach (var l in list)
            {
                Appointment apmnt = new Appointment();
                apmnt.DoctorName = l.DoctorName;
                apmnt.OptStart = l.OptStart;
                appnmnts.Add(apmnt);
            }
            return PartialView("PatientHistory",appnmnts);
        }

        public PartialViewResult PatientProfile()
        {
            string username = Convert.ToString(Session["userid"]);
            var PatProfile = _Context.Patient.Where(i => i.UserId == username).Select(i => new { i.PName, i.PAddress, i.PPhone, i.PEmail, i.PGender, i.PDob }).ToList();
            List<Patient> patlist = new List<Patient>();
            foreach(var i in PatProfile)
            {
                Patient patin = new Patient();
                patin.PName = i.PName;
                patin.PAddress = i.PAddress;
                patin.PPhone = i.PPhone;
                patin.PEmail = i.PEmail;
                patin.PGender = i.PGender;
                patin.PDob = i.PDob;
                patlist.Add(patin);
            }
            return PartialView("PatientProfile", patlist);
        }

        public ActionResult DoctortHome()
        {
            return View("DoctorHome");
        }

        public PartialViewResult DoctorHistory()
        {
            string username = Convert.ToString(Session["userid"]);
            var DocName = _Context.Staff.Where(i => i.SUserId == username).Select(i => i.SName).Single();
            var list = _Context.Appointment.Where(i => i.DoctorName == DocName).Select(i => new { i.PatName, i.OptStart }).OrderByDescending(i=>i.OptStart).ToList();
            List<Appointment> appnmnts1 = new List<Appointment>();
            foreach (var l in list)
            {
                Appointment apmnt1 = new Appointment();
                apmnt1.PatName = l.PatName;
                apmnt1.OptStart = l.OptStart;
                appnmnts1.Add(apmnt1);
            }
            return PartialView("DoctorHistory", appnmnts1);
        }
        public PartialViewResult DoctorProfile()
        {
            string username = Convert.ToString(Session["userid"]);
            var DocProfile = _Context.Staff.Where(i => i.SUserId == username).Select(i => new { i.SName, i.Qualification, i.SPhone, i.SGender}).ToList();
            List<Staff> doclist = new List<Staff>();
            foreach (var i in DocProfile)
            {
                Staff docin = new Staff();
                docin.SName = i.SName;
                docin.Qualification = i.Qualification;
                docin.SPhone = i.SPhone;
                docin.SGender = i.SGender;
                doclist.Add(docin);
            }
            return PartialView("DoctorProfile",doclist);
        }

        public PartialViewResult CheckAppointments()
        {

            return PartialView("");
        }

        [HttpGet]
        public ActionResult HomePage()
        {
            string username = Convert.ToString(Session["userid"]);
            if (username == null)
            {
                return RedirectToAction("LoginCheck", "Hims");
            }
            var patients = _Context.Patient.Count(p => p.UserId == username);
            var doctors = _Context.Staff.Count(p => p.SUserId == username);
            if (patients == 1)
            {
                return RedirectToAction("PatientHome", "Hims");
            }

            if (doctors == 1)
            {
                return RedirectToAction("DoctortHome", "Hims");
            }

            return HttpNotFound();
        }

        public ActionResult LogOff()
        {
            Session.RemoveAll();
            return RedirectToAction("LoginCheck", "Hims");
        }
    }
}