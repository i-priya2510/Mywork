using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class Weather
    {
        public DateTime Date { get; set; }
        [Key]
        public string City { get; set; }
        public float highTemp { get; set; }
        public float lowTemp { get; set; }
        public string forcast { get; set; }
    }
}