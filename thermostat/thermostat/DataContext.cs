using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thermostat.Models;

namespace thermostat
{
    public class DataContext : IdentityDbContext<User, Role, ulong>
    {
        public DbSet<Thermostat> Thermostats { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            // B8:27:EB:3B:6B:C8
            base.OnModelCreating(builder);
        }
    }
}
