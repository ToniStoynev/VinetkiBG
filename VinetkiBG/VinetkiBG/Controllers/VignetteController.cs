using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinetkiBG.Data;
using VinetkiBG.Domain;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Models.ServiceModels;
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

            var vignetteServiceModel = new VignetteServiceModel
            {
                Category = input.VignetteType,
                StartDate = input.StartDate,
                VehicleId = input.VehicleId
            };

            vignetteServiceModel.EndDate = input.StartDate;
            decimal price = 0.0M;

            switch (input.VignetteType)
            {
                case "Weekend":
                    vignetteServiceModel.EndDate = input.StartDate.AddDays(3);
                    vignetteServiceModel.Price = 10;
                    break;
                case "Weekly":
                    vignetteServiceModel.EndDate = input.StartDate.AddDays(7);
                    vignetteServiceModel.Price = 15;
                    break;
                case "Monthly":
                    vignetteServiceModel.EndDate = input.StartDate.AddMonths(1);
                    vignetteServiceModel.Price = 30;
                    break;
                case "Yearly":
                    vignetteServiceModel.EndDate = input.StartDate.AddYears(1);
                    vignetteServiceModel.Price = 97;
                    break;
                default:
                    break;
            }

            var vignetteId  = this.vignneteService.BuyVignette(vignetteServiceModel);

            var currentVehicle = this.vehicleService.GetVechileById(vignetteServiceModel.VehicleId);
    
            var receipt = new ReceiptServiceModel
            {
                LicensePlate = currentVehicle.PlateNumber,
                VehicleType = currentVehicle.VehicleType,
                StartDate = input.StartDate,
                EndDate = vignetteServiceModel.EndDate,
                Price = vignetteServiceModel.Price,
                VignetteId = vignetteId
            };

            var receiptInDb = this.receiptService.CreateReceipt(receipt);
            return this.Redirect($"/Receipt/My/{receiptInDb}");
        }
    }
}