using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VinetkiBG.Domain;
using VinetkiBG.Models;
using VinetkiBG.Models.ViewModels;
using VinetkiBG.Services;

namespace VinetkiBG.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<VinetkiBGUser> manager;

        public HomeController(IUserService userService, UserManager<VinetkiBGUser> manager)
        {
            this.userService = userService;
            this.manager = manager;
        }
        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public IActionResult Profile()
        {
            var id = manager.GetUserId(this.User);



            var user = this.userService.GetUserById(id);


            int vehicleCount = userService.GetVehicleCountByUserId(id);
                
            var model = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                VehiclesCount = vehicleCount
            };

            return this.View(model);
        }

        public IActionResult VignetteCheck()
        {
            return this.View();
        }
    }
}
