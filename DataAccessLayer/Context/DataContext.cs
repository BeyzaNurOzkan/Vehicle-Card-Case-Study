using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class DataContext:DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehiclesType> VehicleTypes { get; set; }
    }
}
