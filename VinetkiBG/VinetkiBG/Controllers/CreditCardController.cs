using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Models.ServiceModels;
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
        public IActionResult All()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var model = this.creditCardService
                .GetAllCards(userId)
                .ToList();

            return View(model);
        }

        [Authorize]
        public IActionResult Register()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Register(RegisterCreditCarBindingModel registerCreditCarBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var creditCardServiceModel = AutoMapper.Mapper.Map<CreditCardServiceModel>(registerCreditCarBindingModel);
            creditCardServiceModel.CardHolderId =  this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var result = this.creditCardService.Register(creditCardServiceModel);

            return this.Redirect("/CreditCard/All");
        }

        [Authorize]
        public IActionResult PayPenalty(string id)
        {
            var model = this.creditCardService.GetCreditCardById(id);

            return this.View(model);
        }
    }
}