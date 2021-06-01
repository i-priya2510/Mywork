using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementProject.Models
{
    public class Appointments
    {
        [Key]
        public int Appointment_Id { get; set; }
        [Display(Name = "Patient's Name")]
        [Required(ErrorMessage = "You have to enter Patient's Name")]
        public String FirstName { get; set; }
        [Display(Name = "Specialization Required")]
        [Required(ErrorMessage = "You have to select the Specialization Required")]
        public string Specialization_Required { get; set; }
        [Required(ErrorMessage = "You have to select the doctor you want")]
        public string Doctor { get; set; }
        [Display(Name = "Appointment Date and Time")]
        [Required(ErrorMessage = "You have to select the Specialization Required")]
        public DateTime Appointment_time { get; set; }
        
    }
}