﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Models.ViewModels;
using VinetkiBG.Services;

namespace VinetkiBG.Controllers
{
    public class ViolationController : Controller
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
        [HttpGet]
        public IActionResult Details(string id)
        {
            var violationFromDb = this.violationService.GetViolationById(id);

            var model = new ViolationDetailsViewModel
            {
                Id = violationFromDb.Id,
                ViolationType = violationFromDb.ViolationType,
                Road = violationFromDb.Road,
                PenaltyAmount = violationFromDb.PenaltyAmount,
                ViolationDate = violationFromDb.ViolationDate,
                VehicleId = violationFromDb.VehicleId
            };

            return this.View(model);
        }

        [Authorize]
        public IActionResult NotFound()
        {
            return this.View(); 
        }
    }
}