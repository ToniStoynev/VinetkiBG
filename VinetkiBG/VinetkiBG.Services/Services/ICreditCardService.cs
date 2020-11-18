namespace VinetkiBG.Services
{
    using VinetkiBG.Models.ServiceModels;
    using VinetkiBG.Services.Common;

    public interface ICreditCardService : IService
    {
        bool Register(CreditCardServiceModel creditCardServiceModel);

        //IQueryable<CreditCardAllViewModel> GetAllCards(string id);

        //CreditCardDetailsViewModel GetCreditCardById(string id);

        bool PayPenalty(string cardId, decimal violationAmount);

        bool DeleteViolation(string id);
    }
}
