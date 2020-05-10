
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleUtils;

namespace CarStoreApplication.Context
{
    public class VehiclesDBContext : DbContext
    {
        public VehiclesDBContext (DbContextOptions<VehiclesDBContext> options) : base(options)
        {

        }

        public DbSet<VehicleForDb> VehiclesDbSet { get; set; }

        
    }
}
