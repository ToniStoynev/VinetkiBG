using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Models.ViewModels;
using VinetkiBG.Services;

namespace VinetkiBG.Areas.Administration.Controllers
{
    public class VignetteController : AdminController
    {
        private readonly IVehicleService vehicleService;
        private readonly IVignneteService vignneteService;

        public VignetteController(IVehicleService vehicleService, IVignneteService vignneteService)
        {
            this.vehicleService = vehicleService;
            this.vignneteService = vignneteService;
        }

        [HttpGet]
        public IActionResult VignetteCheck()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult VignetteCheck(VignetteCheckInputModel input)
        {

            var vechileFromDb = this.vehicleService
                .GetVechileByCountryAndLicensePlate(input.Country, input.PlateNumber);

            if (vechileFromDb == null)
            {
                return this.Redirect("/Violation/NotFoundVehicle");
            }

            var vignetteFromDb = this.vignneteService.CheckVignette(input.Country, input.PlateNumber);

            if (vignetteFromDb == null && vechileFromDb.ViolationId == null)
            {
                return this.Redirect($"/Violation/Register/{vechileFromDb.Id}");
            }

            if (vignetteFromDb == null && vechileFromDb.ViolationId != null)
            {
                return this.Redirect($"/Violation/Details/{vechileFromDb.ViolationId}");
            }

            return this.Redirect($"/Administration/Vignette/Details/{vignetteFromDb.Id}");
        }

        public IActionResult NotFoundVignette()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var vignetteFromDb = this.vignneteService.GetVignetteById(id);

            string status = "Active";

            if (vignetteFromDb.EndDate < DateTime.UtcNow)
            {
                status = "Expired";
            }

            var model = new VignetteDetailsViewModel
            {
                Id = vignetteFromDb.Id,
                VehicleType = vignetteFromDb.Vechile.VechileType,
                StartDate = vignetteFromDb.StartDate,
                EndDate = vignetteFromDb.EndDate,
                Price = vignetteFromDb.Price,
                Status = status,
                VehicleId = vignetteFromDb.VechileId
            };

            return this.View(model);
        }
    }
}
