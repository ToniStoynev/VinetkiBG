using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Services;

namespace VinetkiBG.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleService vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
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
            this.vehicleService.CreateVehicle(model.FriendlyName, model.Type, model.Country, model.PlateNumber);

            return this.Redirect("/Vehicles/All");
        }

        public IActionResult All()
        {
            var viewModel = this.vehicleService.GetAll();
            return this.View(viewModel);
        }
    }
}