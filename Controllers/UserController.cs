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
    public class UserController : Controller
    {
        private IUser<Users> _repo;
        public UserController(IUser<Users> repo)
        {
            _repo = repo;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login( Users user)
        {
            try
            {
                if (_repo.Update(user))
                {
                    ViewBag.Name = user.FirstName;
                    return RedirectToAction("Index", "ClinicHome");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}