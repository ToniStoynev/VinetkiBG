using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VinetkiBG.Domain;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Services;

namespace VinetkiBG.Controllers
{
    public class CreditCardController : Controller
    {
        private readonly ICreditCardService creditCardService;
        private readonly UserManager<VinetkiBGUser> manager;

        public CreditCardController(ICreditCardService creditCardService, UserManager<VinetkiBGUser> manager)
        {
            this.creditCardService = creditCardService;
            this.manager = manager;
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

            if (!this.ModelState.IsValid)
            {
                return View();
            }
            var userId = manager.GetUserId(this.User);
            this.creditCardService.AddCreditCard(input.CardHolderName, input.CreditCardNumber,
                input.CVV, input.ExpirationDate, userId);

            return this.Redirect("/CreditCard/Success");
        }

        public IActionResult Success()
        {
            return this.View();
        }

    }
}