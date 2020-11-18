namespace VinetkiBG.Services
{
   
    using System.Linq;
    using VinetkiBG.Data;
    using VinetkiBG.Domain;
    using VinetkiBG.Models.ServiceModels;
    using VinetkiBG.Services.Mapping;
    public class CreditCardService : ICreditCardService
    {
        private readonly VinetkiBGDbContext context;

        public CreditCardService(VinetkiBGDbContext context)
        {
            this.context = context;
        }
        public bool DeleteViolation(string id)
        {
           var vehicleFromDb = this.context.Vehicles
                .FirstOrDefault(x => x.ViolationId == id);
            vehicleFromDb.ViolationId = null;

            var violationFromDb = this.context.Violations
                .SingleOrDefault(x => x.Id == id);

            this.context.Update(vehicleFromDb);
            this.context.Violations.Remove(violationFromDb);

            int result = this.context.SaveChanges();
            return result > 0;
        }

        //public IQueryable<CreditCardAllViewModel> GetAllCards(string id)
        //{
        //    var creditCards = this.context.CreditCards
        //        .Where(x => x.CardHolderId == id)
        //        .To<CreditCardAllViewModel>();

        //    return creditCards;
        //}

        //public CreditCardDetailsViewModel GetCreditCardById(string id)
        //{
        //    var creditCardFromDb = this.context.CreditCards
        //        .SingleOrDefault(x => x.Id == id);

        //    var creditCard = AutoMapper.Mapper.Map<CreditCardDetailsViewModel>(creditCardFromDb);

        //    return creditCard;
        //}

        public bool PayPenalty(string cardId, decimal violationAmount)
        {
            var creditCardFromDb = this.context.CreditCards
                .SingleOrDefault(x => x.Id == cardId);

            creditCardFromDb.TotalAmount -= violationAmount;
            this.context.Update(creditCardFromDb);

            int result = this.context.SaveChanges();
            return result > 0;
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
