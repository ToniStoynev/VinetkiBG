using Microsoft.EntityFrameworkCore;
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
    public class VignetteService : IVignneteService
    {
        private readonly VinetkiBGDbContext db;

        public VignetteService(VinetkiBGDbContext db)
        {
            this.db = db;
        }

        public string BuyVignette(VignetteServiceModel vignetteServiceModel)
        {
            var vignette = AutoMapper.Mapper.Map<Vignette>(vignetteServiceModel);

            var vehicleFromDb = this.db.Vehicles
                .SingleOrDefault(x => x.Id == vignetteServiceModel.VehicleId);

            this.db.Vignettes.Add(vignette);

            vehicleFromDb.VignetteId = vignette.Id;

            this.db.Update(vehicleFromDb);

            this.db.SaveChanges();

            return vignette.Id;
        }

        public VignetteServiceModel CheckVignette(CheckVehicleServiceModel checkVehicleServiceModel)
        {
            var vehicleFromdb = this.db.Vehicles
            .SingleOrDefault(x => x.Country == checkVehicleServiceModel.Country
            && x.PlateNumber == checkVehicleServiceModel.LicensePlate);

            if (vehicleFromdb == null)
            {
                return null;
            }

            var vignetteFromDb = this.db.Vignettes
                .FirstOrDefault(x => x.Id == vehicleFromdb.VignetteId);

            if (vignetteFromDb == null)
            {
                return null;
            }

            var vignetteServiceModel = AutoMapper.Mapper.Map<VignetteServiceModel>(vignetteFromDb);
           
            return vignetteServiceModel;
        }

        public VignetteServiceModel GetVignetteById(string id)
        {
            var vignetteFromDb = this.db.Vignettes
                .Include(x => x.Vehicle)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            var vignetteServiceModel = AutoMapper.Mapper.Map<VignetteServiceModel>(vignetteFromDb);

            return vignetteServiceModel;
        }
    }
}
