using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VinetkiBG.Domain
{
    public class CredtiCard
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

        [Required]
        public string CardHolderId { get; set; }
        public VinetkiBGUser CardHolder { get; set; }
    }
}
