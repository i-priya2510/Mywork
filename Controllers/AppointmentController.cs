using ClinicManagementProject.Models;
using ClinicManagementProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementProject.Controllers
{
    public class AppointmentController : Controller
    {
        private ClinicContext _context;
        private ILogger<AppointmentController> _logger;
        private IAppointment<Appointments> _repo;
        public AppointmentController(ClinicContext context,IAppointment<Appointments> repo, ILogger<AppointmentController> logger)
        {
            _context = context;
            _logger = logger;
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<Appointments> appointments = _repo.GetAll().ToList();
            return View(appointments);
        }
        public IActionResult AddSpecialization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSpecialization(String Specialization_Required)
        {           
            try 
            {
                TempData["spec"] = Specialization_Required;
            }
            catch
            {
                return View();
            }
            return View();
        }
        public IActionResult AddPointment()
        {
            return View();
            
        }
        [HttpPost]
        [HttpGet]
        public IActionResult AddPointment(Appointments appointment)
        {
            var docs = _context.Doctors.ToList();
            ViewBag.items = docs.Where(i => i.Specialization == Convert.ToString(TempData["spec"])).Select(i => i.FirstName).ToList();
            try
            {
                Appointments app = new Appointments();
                app.FirstName = appointment.FirstName;
                app.Specialization_Required = Convert.ToString(TempData["spec"]);
                app.Doctor = appointment.Doctor;
                app.Appointment_time = appointment.Appointment_time;
                if (_repo.Add(app))
                {
                    ViewBag.addapp = "Appointment Recorded";
                }
                else
                {
                    ViewBag.addapp = "Sorry couldn't add the record try again";
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        public IActionResult DeleteAppointment(int id)
        {
            Appointments appointment = _repo.Get(id);
            return View(appointment);
        }
        [HttpPost]
        public IActionResult DeleteAppointment(Appointments appointment)
        {
            try
            {
                if (_repo.Delete(appointment))
                {
                    ViewBag.delapp = "Record deleted";
                }
                else
                {
                    ViewBag.delapp = "Sorry couldn't add the record try again";
                }
            }
            catch
            {
                return View();
            }
            return View();
        }
    }
}