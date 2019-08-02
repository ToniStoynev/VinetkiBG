using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VinetkiBG.Domain;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Services;

namespace VinetkiBG.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly UserManager<VinetkiBGUser> manager;

        public VehiclesController(IVehicleService vehicleService, UserManager<VinetkiBGUser> manager)
        {
            this.vehicleService = vehicleService;
            this.manager = manager;
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(AddVechileBidingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Vehicles/Add");
            }

            var currentUserId = manager.GetUserId(this.User);

            VehicleServiceModel vehicleServiceModel = new VehicleServiceModel
            {
                Brand = model.FriendlyName,
                Country = model.Country,
                PlateNumber = model.PlateNumber,
                VehicleType = model.Type,
                OwnerId = currentUserId
            };

            var isRegisterdNewVehicle = this.vehicleService.CreateVehicle(vehicleServiceModel);

            if (!isRegisterdNewVehicle)
            {
                return this.Redirect("/Vehicles/UnsecessfullRegistration");
            }

            return this.Redirect("/Vehicles/All");
        }

        [Authorize]
        public IActionResult All()
        {
            var id = manager.GetUserId(this.User);

            var viewModel = this.vehicleService
                .GetAll(id)
                .ToList();

            return this.View(viewModel);
        }
    }
}