using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
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
        private readonly VinetkiBGDbContext db;

        public VehicleService(VinetkiBGDbContext db)
        {
            this.db = db;
        }
        public void CreateVehicle(string name, string type, string country, string plateNumber, string ownerId)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Id == ownerId);

            Vechile vechile = new Vechile
            {
                Brand = name,
                VechileType = type,
                Country = country,
                PlateNumber = plateNumber,
                OwnerId = ownerId
            };

            user.Vechiles.Add(vechile);
            this.db.SaveChanges();
        }

        public IEnumerable<VehicleViewAllModel> GetAll(string id)
        {
            ;
            var all = db.Vechiles.ToList();

            var result = this.db.Vechiles
                .Where(x => x.OwnerId == id)
                .Select(x => new VehicleViewAllModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    VehicleType = x.VechileType,
                    Country = x.Country,
                    LicencePlate = x.PlateNumber
                })
                .ToList();

            return result;
        }

        public Vechile GetVechileByCountryAndLicensePlate(string country, string licensePlate)
        {
            var vehicle = this.db.Vechiles
                .Where(x => x.Country == country && x.PlateNumber == licensePlate)
                .FirstOrDefault();

            return vehicle;
        }

        public Vechile GetVechileById(string id)
        {
            var vehicle = this.db.Vechiles
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return vehicle;
        }

    }
}
