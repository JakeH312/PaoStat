using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thermostat.Models;

namespace thermostat.Controllers
{
    public class ThermostatsController : ApiBase
    {
        public ThermostatsController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        [HttpGet]
        public async Task<ActionResult<ICollection<ThermostatGetDto>>> GetThermostats()
        {
            return Ok(await DataContext.Thermostats.Select(t => ThermostatGetDtoConversion(t)).ToArrayAsync());
        }

        [HttpPost]
        public async Task<ActionResult<ThermostatGetDto>> CreateThermostat()
        {
            var thermostat = new Thermostat()
            {
                Code = "B8:27:EB:3B:6B:C8",
                Location = "CSIT",
                MacAddr = "B8:27:EB:3B:6B:C8",
                Name = "Test Device",
                TemperatureSetting = 60.0
            };

            await DataContext.Thermostats.AddAsync(thermostat);

            await DataContext.SaveChangesAsync();
            return Ok(ThermostatGetDtoConversion(thermostat));
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<ThermostatGetDto>> GetThermostat([FromRoute]string code)
        {
            var thermostat = await GetThermostatByCode(code);
            return thermostat != null ? (ActionResult)Ok(ThermostatGetDtoConversion(thermostat)) : NotFound();
        }

        [HttpGet("{code}/temperature/{newTemp}")]
        public async Task<ActionResult<ThermostatGetDto>> UpdateTemperature([FromRoute]string code, [FromRoute]double newTemp)
        {
            var thermostat = await GetThermostatByCode(code);

            if (thermostat == null) return BadRequest($"No Thermostats exist with the code provided: {code}");

            thermostat.TemperatureSetting = newTemp;
            await DataContext.SaveChangesAsync();

            return Ok(ThermostatGetDtoConversion(thermostat));
        }
    }
}
