using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileProject.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Qualification { get; set; }
        public string IsEmployed { get; set; }
        public DateTime NoticePeriod { get; set; }  
        public float CurrentCTC { get; set; }
    }
}