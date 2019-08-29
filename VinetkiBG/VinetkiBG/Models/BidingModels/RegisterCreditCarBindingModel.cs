using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Services.Mapping;

namespace VinetkiBG.Models.BidingModels
{
    public class RegisterCreditCarBindingModel : IMapTo<CreditCardServiceModel>
    {
        private const string BankErrorMessage = "Bank Name should be between 3 and 12 symbols";
        private const string IBANErrorMessage = "IBAN should be exactly 10 characters";
        private const string BICErrorMessage = "BIC should be between 4 and 9 characters";
        private const string AmountErrorMessage = "Amount should be between 10 and 1 000 000";
        public string Id { get; set; }

        [Required]
        [StringLength(maximumLength: 12, ErrorMessage = BankErrorMessage, MinimumLength =3)]
        public string BankName { get; set; }

        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = IBANErrorMessage, MinimumLength = 10)]
        public string IBAN { get; set; }

        [Required]
        [StringLength(maximumLength: 9, ErrorMessage = BICErrorMessage, MinimumLength = 4)]
        public string BIC { get; set; }

        [Required]
        [Range(10, 1000000, ErrorMessage = AmountErrorMessage)]
        public decimal TotalAmount { get; set; }

    }
}
