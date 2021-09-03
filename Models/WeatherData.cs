using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApplication.Models
{
    public class WeatherData
    {
        public WeatherData()
        {
            time_stamp = DateTime.Now;
        }

        [Key]
        public int key { get; set; }
        public int humidity { get; set; }
        public int temperature { get; set; }
        public int min_temperature { get; set; }
        public int max_temperature { get; set; }
        public DateTime time_stamp { get; set; }
    }
}
