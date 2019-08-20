using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Models.ViewModels;

namespace VinetkiBG.Services
{
    public interface ICreditCardService
    {
        bool Register(CreditCardServiceModel creditCardServiceModel);

        IQueryable<CreditCardAllViewModel> GetAllCards(string id);

        CreditCardDetailsViewModel GetCreditCardById(string id);

        bool PayPenalty(string id);
    }
}
