using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Models.ServiceModels;
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
            var checkVehicleServiceModel = new CheckVehicleServiceModel
            {
                Country = input.Country,
                LicensePlate = input.PlateNumber
            };

            var vechileFromDb = this.vehicleService
                .GetVechileByCountryAndLicensePlate(checkVehicleServiceModel);

            if (vechileFromDb == null)
            {
                return this.Redirect("/Administration/Violation/NotFoundVehicle");
            }

            var vignetteFromDb = this.vignneteService.CheckVignette(checkVehicleServiceModel);

            if (vignetteFromDb == null && vechileFromDb.ViolationId == null)
            {
                return this.Redirect($"/Administration/Violation/Register/{vechileFromDb.ViolationId}");
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

            var model = AutoMapper.Mapper.Map<VignetteDetailsViewModel>(vignetteFromDb);
            model.Status = status;

            return this.View(model);
        }
    }
}
