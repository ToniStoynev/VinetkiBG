using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VinetkiBG.Domain;
using VinetkiBG.Models.BidingModels;
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

            this.vehicleService.CreateVehicle(model.FriendlyName, model.Type, model.Country, model.PlateNumber, currentUserId);

            return this.Redirect("/Vehicles/All");
        }

        [Authorize]
        public IActionResult All()
        {
            var id = manager.GetUserId(this.User);

            var viewModel = this.vehicleService.GetAll(id);


            return this.View(viewModel);
        }
    }
}