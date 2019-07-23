using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Data;
using VinetkiBG.Domain;
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

        public Vignette BuyVignette(string type, decimal price, DateTime starDate, 
            DateTime endDate, string vehicleID)
        {
            var vignette = new Vignette
            {
                Caterory = type,
                Price = price,
                EndDate = endDate,
                StartDate = starDate,
                VechileId = vehicleID
            };

            var vehicle = this.db.Vechiles
                .Where(x => x.Id == vehicleID)
                .FirstOrDefault();

            this.db.Vignettes.Add(vignette);

            vehicle.VignetteId = vignette.Id;
            this.db.SaveChanges();

            return vignette;
        }

        public Vignette CheckVignette(string country, string licensePlate)
        {
           //this.db.Vignettes.Where(x => x.)
                return null;
        }
    }
}
