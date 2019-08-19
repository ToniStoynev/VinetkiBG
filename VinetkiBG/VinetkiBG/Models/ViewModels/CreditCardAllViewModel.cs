using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;
using VinetkiBG.Services.Mapping;

namespace VinetkiBG.Models.ViewModels
{
    public class CreditCardAllViewModel : IMapFrom<CredtiCard>
    {
        public string Id { get; set; }
        public string BankName { get; set; }

        public string IBAN { get; set; }

        public string BIC { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
