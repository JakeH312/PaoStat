using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thermostat.Models
{
    public class Thermostat
    {
        /* Internal Device Identifiers */
        public int Id { get; set; }
        public string MacAddr { get; set; }

        /* External Device Identitifers */
        public string Code { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        /* Device Parameters */
        public double TemperatureSetting { get; set; }

        /* Device Readings */
        public double HumidityReading { get; set; }
        public double TemperatureReading { get; set; }
    }
}
