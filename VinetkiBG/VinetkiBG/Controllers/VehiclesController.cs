using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var vehicleServiceModel = AutoMapper.Mapper.Map<VehicleServiceModel>(model);
            vehicleServiceModel.OwnerId = userId;

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
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var viewModel = this.vehicleService
                .GetAll(userId)
                .ToList();

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            ViewData["VehicleId"] = id;

            var vehicleFromDb = this.vehicleService.GetVechileById(id);

            var model = AutoMapper.Mapper.Map<EditVehicleBindingModel>(vehicleFromDb);

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(EditVehicleBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var result = this.vehicleService.EditVehicle(model);

            return this.Redirect("/Vehicles/All");
        }
    }
}