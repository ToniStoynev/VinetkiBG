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
            var vignette = new Vignette
            {
                Caterory = vignetteServiceModel.Category,
                Price = vignetteServiceModel.Price,
                EndDate = vignetteServiceModel.EndDate,
                StartDate = vignetteServiceModel.StartDate,
                VechileId = vignetteServiceModel.VehicleId
            };

            var vehicleFromDb = this.db.Vechiles
                .SingleOrDefault(x => x.Id == vignetteServiceModel.VehicleId);

            this.db.Vignettes.Add(vignette);

            vehicleFromDb.VignetteId = vignette.Id;

            this.db.SaveChanges();

            return vignette.Id;
        }

        public VignetteServiceModel CheckVignette(CheckVehicleServiceModel checkVehicleServiceModel)
        {
            var vehicleFromdb = this.db.Vechiles
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

            var vignetteServiceModel = new VignetteServiceModel
            {
                Id = vignetteFromDb.Id,
                Category = vignetteFromDb.Caterory,
                Price = vignetteFromDb.Price,
                StartDate = vignetteFromDb.StartDate,
                EndDate = vignetteFromDb.EndDate,
                VehicleId = vignetteFromDb.VechileId
            };

            return vignetteServiceModel;
        }

        public VignetteServiceModel GetVignetteById(string id)
        {
            var vignetteFromDb = this.db.Vignettes
                .Include(x => x.Vechile)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            var vignetteServiceModel = new VignetteServiceModel
            {
                Id = vignetteFromDb.Id,
                Category = vignetteFromDb.Caterory,
                StartDate = vignetteFromDb.StartDate,
                EndDate = vignetteFromDb.EndDate,
                Price = vignetteFromDb.Price,
                VehicleId = vignetteFromDb.VechileId,
                VehicleType = vignetteFromDb.Vechile.VechileType
            };

            return vignetteServiceModel;
        }
    }
}
