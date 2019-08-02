using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Services;

namespace VinetkiBG.Areas.Administration.Controllers
{
    public class ViolationController : AdminController
    {
        private readonly IViolationService violationService;
        private readonly IVehicleService vehicleService;
        private readonly IUserService userService;

        public ViolationController(IViolationService violationService, IVehicleService vehicleService,
            IUserService userService)
        {
            this.violationService = violationService;
            this.vehicleService = vehicleService;
            this.userService = userService;
        }

        public IActionResult Register(string id)
        {
            ViewData["vehicleId"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult Register(ViolationRegisterBindingModel model)
        {

            var violation = this.violationService.RegisterViolation(model.ViolationType, model.Road, model.ViolationDate, model.PenaltyAmount, model.VehicleId);

            return this.Redirect($"/Violation/Details/{violation.Id}");
        }

        public IActionResult NotFoundVehicle()
        {
            return this.View();
        }
    }
}
