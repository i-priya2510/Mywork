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
    public class ClinicHomeController : Controller
    {
        private ILogger<ClinicHomeController> _logger;
        private IHome<Doctors> _doc;
        private IHome<Patients> _pat;
        public ClinicHomeController(IHome<Doctors> doc, IHome<Patients> pat, ILogger<ClinicHomeController> logger)
        {
            _logger = logger;
            _doc = doc;
            _pat = pat;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddDoctor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDoctor(Doctors doctor)
        {
            try
            {
                if (_doc.Add(doctor))
                    ViewBag.adddoc = "Record added succesfully";
                else
                {
                    ViewBag.adddoc = "Sorry couldn't add the record try again";
                }
            }
            catch
            {
                return View();
            }
            return View();
        }
        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPatient(Patients patient)
        {
            try
            {
                if (_pat.Add(patient))
                    ViewBag.addpat = "Record added succesfully";
                else
                {
                    ViewBag.addpat = "Sorry couldn't add the record try again";
                }
            }
            catch
            {
                return View();
            }
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Login","User");
        }

    }
}