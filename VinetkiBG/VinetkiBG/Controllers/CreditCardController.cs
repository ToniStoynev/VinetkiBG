using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Services;

namespace VinetkiBG.Controllers
{
    public class CreditCardController : Controller
    {
        private readonly ICreditCardService creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            this.creditCardService = creditCardService;
        }

        [Authorize]
        public IActionResult Details()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Details(CreditCardBindingModel input)
        {
            return View();
        }

    }
}