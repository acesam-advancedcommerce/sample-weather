using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp3.Models
{
    public class Current
    {
        public decimal temp_c { get; set; }

        public decimal wind_kph { get; set; }

        public string wind_dir { get; set; }

        public bool is_day { get; set; }
    }
}
