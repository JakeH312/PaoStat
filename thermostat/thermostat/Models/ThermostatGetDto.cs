using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thermostat.Models
{
    public class ThermostatGetDto
    {
        /* External Device Identitifers */
        public string Code { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        /* Device Parameters */
        public double TemperatureSetting { get; set; }

        /* Device Readings */
        public double HumidityReading { get; set; }
        public double TemperatureReading { get; set; }

        public static explicit operator ThermostatGetDto(Thermostat thermostat)
        {
            return new ThermostatGetDto()
            {
                Name = thermostat.Name,
                Location = thermostat.Location,
                Code = thermostat.Code,
                TemperatureSetting = thermostat.TemperatureSetting,
                TemperatureReading = thermostat.TemperatureReading,
                HumidityReading = thermostat.HumidityReading
            };
        }
    }
}
