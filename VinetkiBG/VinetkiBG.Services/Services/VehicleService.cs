namespace VinetkiBG.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using VinetkiBG.Data;
    using VinetkiBG.Domain;
    using VinetkiBG.Models.ServiceModels;
    using VinetkiBG.Services.Mapping;

    public class VehicleService : IVehicleService
    {
        private readonly VinetkiBGDbContext db;

        public VehicleService(VinetkiBGDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateVehicle(VehicleServiceModel vehicleServiceModel)
        {
            var user = await this.db.Users
                                 .FirstOrDefaultAsync(x => x.Id == vehicleServiceModel.OwnerId);

            var existingVehicleWithNumber = await this.db.Vehicles
                                            .AnyAsync(x => x.PlateNumber == vehicleServiceModel.PlateNumber);

            if (existingVehicleWithNumber)
            {
                return false;
            }

            var vehicle = AutoMapper.Mapper.Map<Vehicle>(vehicleServiceModel);

            user.Vehicles.Add(vehicle);
            int result =  this.db.SaveChanges();

            return result > 0;
        }

        public IQueryable<VehicleServiceModel> GetAll(string id)
        {
            var vehicleServiceModel = this.db
                .Vehicles
                .Where(x => x.OwnerId == id)
                .To<VehicleServiceModel>();

            return vehicleServiceModel;
        }

        public async Task<VehicleServiceModel> GetVechileByCountryAndLicensePlate(CheckVehicleServiceModel checkVehicleServiceModel)
        {
            var vehicleFromDb = await this.db.Vehicles
                                     .Where(x => x.Country == checkVehicleServiceModel.Country
                                     && x.PlateNumber == checkVehicleServiceModel.LicensePlate)
                                    .FirstOrDefaultAsync();

            if (vehicleFromDb == null)
            {
                return null;
            }

            var vehicle = AutoMapper.Mapper.Map<VehicleServiceModel>(vehicleFromDb);

            return vehicle;
        }

        public async Task<VehicleServiceModel> GetVechileById(string id)
        {
            var vehicleFromDb = await this.db.Vehicles
                               .SingleOrDefaultAsync(x => x.Id == id);

            var vehicle = AutoMapper.Mapper.Map<VehicleServiceModel>(vehicleFromDb);

            return vehicle;
        }

        public async Task<bool> EditVehicle(VehicleServiceModel model)
        {
            var vehicleFromDb = await db.Vehicles
                               .SingleOrDefaultAsync(x => x.Id == model.Id);

            if (vehicleFromDb == null)
            {
                return false;
            }

            if (model.Brand != null)
            {
                vehicleFromDb.Brand = model.Brand;
            }
            if (model.Country != null)
            {
                vehicleFromDb.Country = model.Country;
            }
            if (model.Type != null)
            {
                vehicleFromDb.Type = model.Type;
            }
            if (model.PlateNumber != null)
            {
                vehicleFromDb.PlateNumber = model.PlateNumber;
            }
            

            db.Update(vehicleFromDb);

            int result = await db.SaveChangesAsync();

            return result > 0;
        }
    }
}
