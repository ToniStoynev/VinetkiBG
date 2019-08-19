using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VinetkiBG.Models.BidingModels
{
    public class RegisterCreditCarBindingModel
    {
        public string Id { get; set; }

        [Required]
        public string BankName { get; set; }

        [Required]
        public string IBAN { get; set; }

        [Required]
        public string BIC { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

    }
}
