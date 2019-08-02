using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Data;
using VinetkiBG.Domain;
using VinetkiBG.Models.ServiceModels;
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
        public bool CreateVehicle(VehicleServiceModel vehicleServiceModel)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Id == vehicleServiceModel.OwnerId);

            var existingVehicleWithNumber = this.db.Vechiles
                .Any(x => x.PlateNumber == vehicleServiceModel.PlateNumber);

            if (existingVehicleWithNumber)
            {
                return false;
            }

            Vechile vechile = new Vechile
            {
                Brand = vehicleServiceModel.Brand,
                VechileType = vehicleServiceModel.VehicleType,
                Country = vehicleServiceModel.Country,
                PlateNumber = vehicleServiceModel.PlateNumber,
                OwnerId = vehicleServiceModel.OwnerId
            };

            user.Vechiles.Add(vechile);
            int result = this.db.SaveChanges();

            return result > 0;
        }

        public IQueryable<VehicleViewAllModel> GetAll(string id)
        {
            var result = this.db.Vechiles
                .Where(x => x.OwnerId == id)
                .Select(x => new VehicleViewAllModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    VehicleType = x.VechileType,
                    Country = x.Country,
                    LicencePlate = x.PlateNumber,
                    ViolationId = x.ViolationId
                });
               

            return result;
        }

        public VehicleServiceModel GetVechileByCountryAndLicensePlate(CheckVehicleServiceModel checkVehicleServiceModel)
        {
            var vehicleFromDb = this.db.Vechiles
                .Where(x => x.Country == checkVehicleServiceModel.Country
                && x.PlateNumber == checkVehicleServiceModel.LicensePlate)
                .FirstOrDefault();

            if (vehicleFromDb == null)
            {
                return null;
            }

            var vehicle = new VehicleServiceModel
            {
                Brand = vehicleFromDb.Brand,
                VehicleType = vehicleFromDb.VechileType,
                Country = vehicleFromDb.Country,
                PlateNumber = vehicleFromDb.PlateNumber,
                OwnerId = vehicleFromDb.OwnerId,
                ViolationId = vehicleFromDb.ViolationId
            };

            return vehicle;
        }

        public VehicleServiceModel GetVechileById(string id)
        {
            var vehicleFromDb = this.db.Vechiles
                .SingleOrDefault(x => x.Id == id);

                var vehicle =  new VehicleServiceModel
                {
                    Brand = vehicleFromDb.Brand,
                    VehicleType = vehicleFromDb.VechileType,
                    Country = vehicleFromDb.Country,
                    PlateNumber = vehicleFromDb.PlateNumber,
                    OwnerId = vehicleFromDb.OwnerId,
                    ViolationId = vehicleFromDb.ViolationId
                };
                

            return vehicle;
        }

    }
}
