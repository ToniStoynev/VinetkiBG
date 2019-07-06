using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Data;
using VinetkiBG.Domain;

namespace VinetkiBG.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly VinetkiBGDbContext context;

        public VehicleService(VinetkiBGDbContext context)
        {
            this.context = context;
        }
        public void CreateVehicle(string name, string type, string country, string plateNumber)
        {
           
        }
    }
}
