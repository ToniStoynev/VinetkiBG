using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VinetkiBG.Data;
using VinetkiBG.Models.ViewModels;

namespace VinetkiBG.Controllers
{
    public class VignetteController : Controller
    {
        private readonly VinetkiBGDbContext db;

        public VignetteController(VinetkiBGDbContext db)
        {
            this.db = db;
        }
        public IActionResult Purchase(string id)
        {
            var vehicle = this.db.Vechiles.Where(x => x.Id == id).FirstOrDefault();

            var model = new VehicleViewAllModel
            {
                Brand = vehicle.Brand,
                Country = vehicle.Country,
                LicencePlate = vehicle.PlateNumber,
                VehicleType = vehicle.VechileType
            };

            return View(model);
        }
    }
}