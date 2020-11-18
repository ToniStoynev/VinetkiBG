namespace VinetkiBG.Models.ServiceModels
{
    using VinetkiBG.Domain;
    using VinetkiBG.Services.Mapping;

    public class CreditCardServiceModel : IMapFrom<CredtiCard>,  IMapTo<CredtiCard>
    {
        public string Id { get; set; }

        public string BankName { get; set; }
        public string IBAN { get; set; }

        public string BIC { get; set; }
        public decimal TotalAmount { get; set; }

        public string CardHolderId { get; set; }
    }
}
