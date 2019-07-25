using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VinetkiBG.Models.BidingModels
{
    public class ViolationRegisterBindingModel
    {

        [Required]
        public string ViolationType { get; set; }

        [Required]
        public string Road { get; set; }

        [Required]
        public DateTime ViolationDate { get; set; }

        [Required]
        [Range(70, 1800)]
        public decimal PenaltyAmount { get; set; }
    }
}
