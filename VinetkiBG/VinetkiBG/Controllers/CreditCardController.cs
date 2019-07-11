using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VinetkiBG.Controllers
{
    public class CreditCardController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}