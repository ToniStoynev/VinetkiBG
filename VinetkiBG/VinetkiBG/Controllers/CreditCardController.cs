using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinetkiBG.Controllers
{
    public class CreditCardController : Controller
    {
        [Authorize]
        public IActionResult All()
        {
            return View();
        }

        [Authorize]
        public IActionResult Register()
        {
            return this.View();
        }
    }
}