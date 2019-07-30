﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinetkiBG.Data;
using VinetkiBG.Domain;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Models.ViewModels;
using VinetkiBG.Services;

namespace VinetkiBG.Controllers
{
    public class VignetteController : Controller
    {
        private readonly IVignneteService vignneteService;
        private readonly IVehicleService vehicleService;
        private readonly IReceiptService receiptService;

        public VignetteController(IVignneteService vignneteService, 
            IVehicleService vehicleService, IReceiptService receiptService)
        {
            this.vignneteService = vignneteService;
            this.vehicleService = vehicleService;
            this.receiptService = receiptService;
        }

        [Authorize]
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
            var vignette  = this.vignneteService.BuyVignette(input.VignetteType, price, input.StartDate, endDate, input.VehicleId);


            var currentVehicle = this.vehicleService.GetVechileById(vignette.VechileId);
    
            var receipt = new Receipt
            {
                LicensePlate = currentVehicle.PlateNumber,
                VehicleType = currentVehicle.VechileType,
                StartDate = input.StartDate,
                EndDate = endDate,
                Price = price,
                VignetteId = vignette.Id 
            };

            var receiptInDb = this.receiptService.CreateReceipt(receipt);
            return this.Redirect($"/Receipt/My/{receiptInDb.Id}");
        }

       
    }
}