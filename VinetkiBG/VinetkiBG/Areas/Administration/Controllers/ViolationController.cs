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

            var violationServiceModel = AutoMapper.Mapper.Map<ViolationServiceModel>(model);

            var violationId = this.violationService.RegisterViolation(violationServiceModel);

            return this.Redirect($"/Violation/Details/{violationId}");
        }

        public IActionResult Details(string id)
        {
            var violation = this.violationService.GetViolationById(id);

            var model = AutoMapper.Mapper.Map<ViolationDetailsViewModel>(violation);

            return this.View(model);
        }

        public IActionResult NotFoundVehicle()
        {
            return this.View();
        }
    }
}
