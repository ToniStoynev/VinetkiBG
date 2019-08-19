using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Data;
using VinetkiBG.Domain;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Models.ViewModels;
using VinetkiBG.Services.Mapping;

namespace VinetkiBG.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly VinetkiBGDbContext context;

        public CreditCardService(VinetkiBGDbContext context)
        {
            this.context = context;
        }

        public IQueryable<CreditCardAllViewModel> GetAllCards(string id)
        {
            var creditCards = this.context.CreditCards
                .Where(x => x.CardHolderId == id)
                .To<CreditCardAllViewModel>();

            return creditCards;
        }

        public CreditCardDetailsViewModel GetCreditCardById(string id)
        {
            var creditCardFromDb = this.context.CreditCards
                .SingleOrDefault(x => x.Id == id);

            var creditCard = AutoMapper.Mapper.Map<CreditCardDetailsViewModel>(creditCardFromDb);

            return creditCard;
        }

        public bool Register(CreditCardServiceModel creditCardServiceModel)
        {
            var creditCard = AutoMapper.Mapper.Map<CredtiCard>(creditCardServiceModel);

            this.context.CreditCards.Add(creditCard);
            int result = context.SaveChanges();

            return result > 0;
        }
    }
}
