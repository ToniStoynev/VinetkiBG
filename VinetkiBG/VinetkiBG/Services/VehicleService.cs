using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Data;
using VinetkiBG.Domain;
using VinetkiBG.Models.ViewModels;

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
            Vechile vechile = new Vechile
            {
                Brand = name,
                VechileType = type,
                Country = country,
                PlateNumber = plateNumber
            };
            this.context.Vechiles.Add(vechile);
            this.context.SaveChanges();
        }

        public IEnumerable<VehicleViewAllModel> GetAll()
        {
            return this.context.Vechiles.Select(x => new VehicleViewAllModel
            {
                Brand = x.Brand,
                VehicleType = x.VechileType,
                Country = x.Country,
                LicencePlate = x.PlateNumber
            })
            .ToList();
        }
    }
}
