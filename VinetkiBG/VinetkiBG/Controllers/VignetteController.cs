using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VinetkiBG.Controllers
{
    public class VignetteController : Controller
    {
        public IActionResult Purchase()
        {
            return View();
        }
    }
}