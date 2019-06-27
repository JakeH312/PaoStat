using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thermostat.Models;

namespace thermostat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiBase : ControllerBase
    {
        public DataContext DataContext { get; set; }

        public ApiBase(IServiceProvider serviceProvider)
        {
            var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider;
            DataContext = serviceScope.GetService<DataContext>();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<Thermostat> GetThermostatByCode(string code) => await DataContext.Thermostats.FirstOrDefaultAsync(t => t.Code.ToLower() == code.ToLower());

        [ApiExplorerSettings(IgnoreApi = true)]
        public ThermostatGetDto ThermostatGetDtoConversion(Thermostat t) => new ThermostatGetDto()
        {
            Name = t.Name,
            Code = t.Code,
            HumidityReading = t.HumidityReading,
            Location = t.Location,
            TemperatureReading = t.TemperatureReading,
            TemperatureSetting = t.TemperatureSetting
        };
    }
}
