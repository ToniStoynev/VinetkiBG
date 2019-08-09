using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VinetkiBG.Data;
using VinetkiBG.Domain;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Models.ViewModels;
using VinetkiBG.Services.Mapping;

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


            var existingVehicleWithNumber = this.db.Vehicles
                .Any(x => x.PlateNumber == vehicleServiceModel.PlateNumber);

            if (existingVehicleWithNumber)
            {
                return false;
            }

            var vehicle = AutoMapper.Mapper.Map<Vehicle>(vehicleServiceModel);

            user.Vehicles.Add(vehicle);
            int result = this.db.SaveChanges();

            return result > 0;
        }

        public IQueryable<VehicleViewAllModel> GetAll(string id)
        {
            var result = this.db.Vehicles
                .Where(x => x.OwnerId == id)
                .To<VehicleViewAllModel>();
     
            return result;
        }

        public VehicleServiceModel GetVechileByCountryAndLicensePlate(CheckVehicleServiceModel checkVehicleServiceModel)
        {
            var vehicleFromDb = this.db.Vehicles
                .Where(x => x.Country == checkVehicleServiceModel.Country
                && x.PlateNumber == checkVehicleServiceModel.LicensePlate)
                .FirstOrDefault();

            if (vehicleFromDb == null)
            {
                return null;
            }

            var vehicle = AutoMapper.Mapper.Map<VehicleServiceModel>(vehicleFromDb);

            return vehicle;
        }

        public VehicleServiceModel GetVechileById(string id)
        {
            var vehicleFromDb = this.db.Vehicles
                .SingleOrDefault(x => x.Id == id);

            var vehicle = AutoMapper.Mapper.Map<VehicleServiceModel>(vehicleFromDb);

            return vehicle;
        }
    }
}
