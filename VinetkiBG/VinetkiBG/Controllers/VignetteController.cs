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
            ViewData["CarId"] = id;
          
            
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Purchase(PurchaseVignetteBidingModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }


            DateTime endDate = input.StartDate;
            decimal price = 0.0M;

            if (input.VignetteType == "Weekend")
            {
                endDate = input.StartDate.AddDays(3);
                price = 10;
            }
            else if (input.VignetteType == "Weekly")
            {
                endDate = input.StartDate.AddDays(7);
                price = 15;
            }
            else if (input.VignetteType == "Monthly")
            {
                endDate = input.StartDate.AddMonths(1);
                price = 30;
            }
            else if (input.VignetteType == "Yearly")
            {
                endDate = input.StartDate.AddYears(1);
                price = 97;
            }
            this.vignneteService.BuyVignette(input.VignetteType, price, input.StartDate, endDate, input.VehicleId);
            return this.Redirect("/Vignette/Success");
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