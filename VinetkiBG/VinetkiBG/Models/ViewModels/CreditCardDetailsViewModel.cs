using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;
using VinetkiBG.Services.Mapping;

namespace VinetkiBG.Models.ViewModels
{
    public class CreditCardDetailsViewModel : IMapFrom<CredtiCard>
    {
        public string BankName { get; set; }

        public string IBAN { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
