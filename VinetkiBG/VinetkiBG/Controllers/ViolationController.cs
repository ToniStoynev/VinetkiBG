using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinetkiBG.Models.BidingModels;

namespace VinetkiBG.Controllers
{
    public class ViolationController : Controller
    {
        [Authorize(Roles ="Admin")]
        public IActionResult Register(string id)
        {
            ViewData["vehicleId"] = id;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Register(ViolationRegisterBindingModel model)
        {
            string id = ViewData["vehicleId"].ToString();
            return View();
        }


        [Authorize(Roles = "Admin")]
        public IActionResult NotFoundVehicle()
        {
            return this.View();
        }
    }
}