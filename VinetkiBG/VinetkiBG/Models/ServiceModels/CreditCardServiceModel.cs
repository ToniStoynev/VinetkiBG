using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Services.Mapping;

namespace VinetkiBG.Models.ServiceModels
{
    public class CreditCardServiceModel : IMapFrom<RegisterCreditCarBindingModel>,  IMapTo<CredtiCard>
    {
        public string Id { get; set; }

        public string BankName { get; set; }
        public string IBAN { get; set; }

        public string BIC { get; set; }
        public decimal TotalAmount { get; set; }

        public string CardHolderId { get; set; }
    }
}
