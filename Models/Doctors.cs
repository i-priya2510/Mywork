using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementProject.Models
{
    public class Doctors
    {
        [Key]
        public int Doctor_Id { get; set; }
        public String FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public String Specialization { get; set; }
        [Display(Name="Available From")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:H:mm tt}")]
        public DateTime VH_From { get; set; }
        [Display(Name = "Available To")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:h:mm tt}")]
        public DateTime VH_To { get; set; }
    }
}