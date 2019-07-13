using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VinetkiBG.Domain
{
    public class CreditCard
    {
        public string Id { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "Card Holder Name must be between 2 and 12 symbols", MinimumLength = 6)]
        [Required]
        public string CardHolderName { get; set; }

        [StringLength(maximumLength: 12, ErrorMessage = "Credit card number should be exatly 12 symbols", MinimumLength = 12)]
        [Required]
        public string CreditCardNumber { get; set; }

        [StringLength(maximumLength: 3, ErrorMessage = "CVV should be exatly 3 symbols", MinimumLength = 3)]
        [Required]
        public string CVV { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public string UserId { get; set; }
        public VinetkiBGUser Owner { get; set; }
    }
}
