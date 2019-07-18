using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinetkiBG.Data;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Models.ViewModels;
using VinetkiBG.Services;

namespace VinetkiBG.Controllers
{
    public class VignetteController : Controller
    {
        private readonly IVignneteService vignneteService;
        private readonly IVehicleService vehicleService;

        public VignetteController(IVignneteService vignneteService, IVehicleService vehicleService)
        {
            this.vignneteService = vignneteService;
            this.vehicleService = vehicleService;
        }
        public IActionResult Purchase(string id)
        {
            var vehicle = this.vehicleService.GetVechileById(id);

            var model = new VehicleViewAllModel
            {
                Brand = vehicle.Brand,
                Country = vehicle.Country,
                LicencePlate = vehicle.PlateNumber,
                VehicleType = vehicle.VechileType
            };

            return View(model);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult VignetteCheck()
        {
            return this.View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult VignetteCheck(VignetteCheckInputModel input)
        {
            return this.View();
        }
    }
}