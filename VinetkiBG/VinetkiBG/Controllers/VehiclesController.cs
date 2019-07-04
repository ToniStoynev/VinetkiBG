using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinetkiBG.Controllers
{
    public class VehiclesController : Controller
    {
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
    }
}